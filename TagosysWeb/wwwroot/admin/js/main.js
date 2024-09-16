(function ($) {
    "use strict";
    var input = $('.validate-input .input100');
    $('.validate-form').on('submit', function () {
        var check = true;
        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }
        return check;
    });
    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });
    function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }
    function showValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).addClass('alert-validate');
    }
    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }

   
   

    // image popup work


    var imageFile = null;
    var isLoading = false;
    console.log(document.getElementById("imagefile"));
    document.getElementById("imagefile").addEventListener("change", event => {
        const files = event.target.files;
        imageFile = files[0];
    });
    $(document).ready(function () {
        $('#uploadImageButton').click(function () {
            $('#imagefile').val('');
            $('#exampleModalCenter').modal('show');

            $('#exampleModalCenter').modal({
                backdrop: 'static',
                keyboard: false,

            });
        });
        $('#modalSubmitBtn').click(function (e) {
          
            console.log(imageFile);
            e.preventDefault();
            isLoading = true;
           
            if (imageFile == null) {
                toastr.error("Please select an image.");
                return;
            }

            $('#imagefile').prop('disabled', true);
            $('#btnClose').prop('disabled', true);
            $('#modalSubmitBtn').prop('disabled', true);
            $('#loading-spinner').show();
            var formData = new FormData();
            formData.append("ImageFile", imageFile);
            $.ajax({
                method: "POST",
                url: "/../../Admin/ImageGallery/ImageUpload/",
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                   
                    console.log(response);
                    isLoading = false;
                    $('#imagefile').prop('disabled', false);
                    $('#btnClose').prop('disabled', false);
                    $('#modalSubmitBtn').prop('disabled', false);
                    $('#loading-spinner').hide();
                   
                    if (response.succeed) {
                        
                        var fileName = response.data.fileName;
                        var localImagePath = response.data.localImagePath;
                        $('#blah').attr('src', localImagePath);
                        document.getElementById("imagefiles").value = fileName;
                      
                        //--------
                        $('#previousImage').attr('src', '');
                        $('#previousImage').hide();
                        //-------
                        
                        toastr.success("Image Save successfully.", "Success");

                        $('#exampleModalCenter').modal('hide'); 
                    } else {
                        toastr.error("An error occurred while updating Image.", "Error");
                    }
                },
                error: function () {
                    isLoading = false;
                  
                    $('#loading-spinner').hide();
                    toastr.error("An error occurred while uploading the image.", "Error");
                }
            });
        });
    });


    $('#btnClose').click(function () {

        imageFile = null;
        $('#previousImage').attr('src', '');
        $('#previousImage').hide();
    });

})
    (jQuery);
