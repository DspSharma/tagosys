$(document).ready(function () {
    $.ajax(
        {
            method: "GET",
            url: "/../Admin/SystemSetting/getSystemSetting",
        })
        .done(function (res) {
            console.log(res);
            $('#foteremail').html(res.email);
            $('#contactemail').html(res.email);
            $('#facebookUrl').html(res.facebookUrl);
            $('#instagramUrl').html(res.instagramUrl);
            $('#youTubeUrl').html(res.youTubeUrl);
            $('#localImage').html(res.localImage);
            $('#logo').html(res.logo);
           // $('#contactMapUrl').html(res.mapUrl);
            $('#contactMapUrl').attr('src', res.mapUrl);
            $('#mobile').html(res.mobile);
            $('#contactmobile').html(res.mobile);
            $('#name').html(res.name);
            $('#operationalOfficeAddress').html(res.operationalOfficeAddress);
            $('#registeredOfficeAddress').html(res.registeredOfficeAddress);
            $('#twitterUrl').html(res.twitterUrl);


            res.facebookUrl != null ? $('#facebookUrlfooter').attr('href', res.facebookUrl) : $('#facebookUrlfooter').remove();
            res.instagramUrl != null ? $('#instagramUrlfooter').attr('href', res.instagramUrl) : $('#instagramUrlfooter').remove();
            res.twitterUrl != null ? $('#twitterUrlfooter').attr('href', res.twitterUrl) : $('#twitterUrlfooter').remove();
            res.youTubeUrl != null ? $('#youTubeUrlfooter').attr('href', res.linkedinurl) : $('#youTubeUrlfooter').remove();

        });
});