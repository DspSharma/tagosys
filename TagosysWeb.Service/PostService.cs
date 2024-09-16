using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Entities;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.Service
{
    public class PostService : IPostService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;
        public ISystemSettingService _systemSettingService;
        public IImageService _imageService;

        public PostService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper, ISystemSettingService systemSettingService, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _systemSettingService = systemSettingService;
            _imageService = imageService;
        }


        public async Task<ApiResponseModels<PostOutput>> addUpdatePost(PostInput model)
        {
            Post formValue = _mapper.Map<Post>(model);
            if (formValue.Id != 0)
            {
                Post post = await _unitOfWork.Post.GetByIdAsync(model.Id);
                if (model.Image != null)
                {
                    if (model.ImageFile != null)
                    {
                        await _imageService.deleteUploadImageLocal(post.Image);
                        post.Image = model.Image;
                    }
                    else
                    {
                        post.Image = model.Image;
                    }
                }
                post.Tittle = model.Tittle;
                post.ShortDescription = model.ShortDescription;
                post.PageId = model.PageId;
                post.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                await _imageService.activeImage(formValue.Image);
                formValue.Image = model.Image;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Post.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<PostOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<PostOutput>> editPost(int id)
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            Post post = await _unitOfWork.Post.GetByIdAsync(id);
            var rslt = _mapper.Map<PostOutput>(post);
            if (rslt != null)
            {
                var thumbImage = post.Image;
                rslt.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<PostOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<PostOutput>>> postList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Post> posts = (await _unitOfWork.Post.GetAllAsync()).ToList();
            //List<Post> posts = _unitOfWork.Post.GetWhere(x=>x.IsActive == true).ToList();
            List<int> listPostId = posts.Select(x=>x.PageId).Distinct().ToList();
            List<Page>pages = _unitOfWork.Page.GetWhere(x=> listPostId.Contains(x.Id)).ToList();
            var postList = from po in posts
                           join pa in pages on po.PageId equals pa.Id
                           select new PostOutput
                           {
                               Id = po.Id,
                               Tittle = po.Tittle,
                               ShortDescription = po.ShortDescription,
                               IsActive = po.IsActive,
                               Image = po.Image,
                               PageId = pa.Id,
                               PageName = pa.Tittle,
                               CreatedAt = po.CreatedAt,
                               UpdatedAt = po.UpdatedAt


                           };
            var reslt = _mapper.Map<List<PostOutput>>(postList);
            foreach (var post in reslt)
            {

                var thumbImage = post.Image;
                post.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<PostOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }

        public async Task<ApiResponseModels<List<PostOutput>>>getPostList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            //List<Post> posts = (await _unitOfWork.Post.GetAllAsync()).ToList();
            List<Post> posts = _unitOfWork.Post.GetWhere(x => x.IsActive == true).ToList();
            List<int> listPostId = posts.Select(x => x.PageId).Distinct().ToList();
            List<Page> pages = _unitOfWork.Page.GetWhere(x => listPostId.Contains(x.Id)).ToList();
            var postList = from po in posts
                           join pa in pages on po.PageId equals pa.Id
                           select new PostOutput
                           {
                               Id = po.Id,
                               Tittle = po.Tittle,
                               ShortDescription = po.ShortDescription,
                               IsActive = po.IsActive,
                               Image = po.Image,
                               PageId = pa.Id,
                               PageName = pa.Tittle,
                               CreatedAt = po.CreatedAt,
                               UpdatedAt = po.UpdatedAt


                           };
            var reslt = _mapper.Map<List<PostOutput>>(postList);
            foreach (var post in reslt)
            {

                var thumbImage = post.Image;
                post.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<PostOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }
       

        public async Task<ApiResponseModels<bool>> postDeleteById(int id)
        {
            Post post = await _unitOfWork.Post.GetByIdAsync(id);
            if (post.Id == id)
            {

                await _imageService.deleteUploadImageLocal(post.Image);
                _unitOfWork.Post.Remove(post);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<bool>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<bool>> activeInActive(int id)
        {
            Post posts = await _unitOfWork.Post.GetByIdAsync(id);
            if (posts.IsActive == true)
            {
                posts.IsActive = false;
            }
            else
            {
                posts.IsActive = true;
            }
            await _unitOfWork.SaveAsync();
            return new ApiResponseModels<bool>
            {
                succeed = true,
                message = "success"
            };
        }

    }
}
