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
    public class PostDescriptionService : IPostDescriptionService
    {
        public IUnitOfWork _unitOfWork;
        public readonly tagosyswebContext _context;
        public IMapper _mapper;
        public ISystemSettingService _systemSettingService;
        public IImageService _imageService;
        public PostDescriptionService(IUnitOfWork unitOfWork, tagosyswebContext context, IMapper mapper, ISystemSettingService systemSettingService, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _systemSettingService = systemSettingService;
            _imageService = imageService;
        }

        public async Task<ApiResponseModels<PostdescriptionOutput>> addUpdatePostDescription(PostdescriptionInput model)
        {
            Post post = await _unitOfWork.Post.GetByIdAsync(model.PostId);
            Postdescription formValue = _mapper.Map<Postdescription>(model);
            if (formValue.Id != 0)
            {
                Postdescription postdescription = await _unitOfWork.Postdescription.GetByIdAsync(model.Id);
                if (model.Image != null)
                {
                    if (model.ImageFile != null)
                    {
                        await _imageService.deleteUploadImageLocal(postdescription.Image);
                        postdescription.Image = model.Image;
                    }
                    else
                    {
                        postdescription.Image = model.Image;
                    }
                }
                postdescription.PostId = formValue.PostId;
                postdescription.Tittle = model.Tittle;
                postdescription.Description = model.Description;
                postdescription.PageId = post.PageId;
                //postdescription.PageId = model.PageId;
                postdescription.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                await _imageService.activeImage(formValue.Image);
                formValue.Image = model.Image;
                formValue.PageId = post.PageId;
                formValue.IsActive = false;
                formValue.CreatedAt = DateTime.UtcNow;
                formValue.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Postdescription.AddAsync(formValue);
                await _unitOfWork.SaveAsync();
            }
            return new ApiResponseModels<PostdescriptionOutput>
            {
                succeed = true,
                message = "success"
            };
        }

        public async Task<ApiResponseModels<PostdescriptionOutput>> editPostDescription(int id)
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            Postdescription post = await _unitOfWork.Postdescription.GetByIdAsync(id);
            var rslt = _mapper.Map<PostdescriptionOutput>(post);
            if (rslt != null)
            {
                var thumbImage = post.Image;
                rslt.LocalImage = res.imageThumbFolder + thumbImage;
            }
            return new ApiResponseModels<PostdescriptionOutput>
            {
                succeed = true,
                message = "success",
                data = rslt
            };
        }

        public async Task<ApiResponseModels<List<PostdescriptionOutput>>> postDescriptionList()
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            List<Postdescription> posts = (await _unitOfWork.Postdescription.GetAllAsync()).ToList();
            List<int> postId = posts.Select(x => x.PostId).Distinct().ToList();
            List<int>pageId = posts.Select(x=>x.PageId).Distinct().ToList();
            List<Page> pages = _unitOfWork.Page.GetWhere(x => pageId.Contains(x.Id)).ToList();
            List<Post>getPost = _unitOfWork.Post.GetWhere(x=>postId.Contains(x.Id)).ToList();
            var PostdescriptionList = from pd in posts
                                      join po in getPost on pd.PostId equals po.Id
                                      join pa in pages on pd.PageId equals pa.Id
                                      select new PostdescriptionOutput
                                      {
                                          Id = pd.Id,
                                          Tittle = pd.Tittle,
                                          Description = pd.Description,
                                          Image = pd.Image,
                                          IsActive = pd.IsActive,
                                          PostId = po.Id,
                                          PostName = po.Tittle,
                                          PageId = pa.Id,
                                          PageName = pa.Tittle,
                                          CreatedAt = pd.CreatedAt,
                                          UpdatedAt = pd.UpdatedAt,
                                      };
           
            var reslt = _mapper.Map<List<PostdescriptionOutput>>(PostdescriptionList);
            foreach (var postdescription in reslt)
            {

                var thumbImage = postdescription.Image;
                postdescription.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<PostdescriptionOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }

        public async Task<ApiResponseModels<List<PostdescriptionOutput>>> postDescriptionById(int id)
        {
            ImageEndpointModel res = await _systemSettingService.getEndpoint();
            //List<Postdescription> posts = (await _unitOfWork.Postdescription.GetAllAsync()).ToList();
            List<Postdescription> posts =  _unitOfWork.Postdescription.GetWhere(x=>x.PostId == id && x.IsActive == true).ToList();
            List<int> postId = posts.Select(x => x.PostId).Distinct().ToList();
            List<int> pageId = posts.Select(x => x.PageId).Distinct().ToList();
            List<Page> pages = _unitOfWork.Page.GetWhere(x => pageId.Contains(x.Id)).ToList();
            List<Post> getPost = _unitOfWork.Post.GetWhere(x => postId.Contains(x.Id)).ToList();
            var PostdescriptionList = from pd in posts
                                      join po in getPost on pd.PostId equals po.Id
                                      join pa in pages on pd.PageId equals pa.Id
                                      select new PostdescriptionOutput
                                      {
                                          Id = pd.Id,
                                          Tittle = pd.Tittle,
                                          Description = pd.Description,
                                          Image = pd.Image,
                                          IsActive = pd.IsActive,
                                          PostId = po.Id,
                                          PostName = po.Tittle,
                                          PageId = pa.Id,
                                          PageName = pa.Tittle,
                                          CreatedAt = pd.CreatedAt,
                                          UpdatedAt = pd.UpdatedAt,
                                      };

            var reslt = _mapper.Map<List<PostdescriptionOutput>>(PostdescriptionList);
            foreach (var postdescription in reslt)
            {

                var thumbImage = postdescription.Image;
                postdescription.LocalImage = res.imageThumbFolder + thumbImage;

            }
            return new ApiResponseModels<List<PostdescriptionOutput>>
            {
                succeed = true,
                message = "success",
                data = reslt
            };
        }

        public async Task<ApiResponseModels<bool>> postDescriptionDeleteById(int id)
        {
            Postdescription post = await _unitOfWork.Postdescription.GetByIdAsync(id);
            if (post.Id == id)
            {

                await _imageService.deleteUploadImageLocal(post.Image);
                _unitOfWork.Postdescription.Remove(post);
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
            Postdescription posts = await _unitOfWork.Postdescription.GetByIdAsync(id);
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
