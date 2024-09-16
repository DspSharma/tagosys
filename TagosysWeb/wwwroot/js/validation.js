
function addUpdateContact() {
   
    let name = $('#contactname').val();
    let contactEmail = $('#email').val();
    let subject = $('#contactsubject').val();
    let Message = $('#contactMessage').val();
    var Nameregex = /^[a-zA-Z][a-zA-Z ]*$/;
    var Emailregex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var messageregex = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;
    $(".error").remove();

    if (name == '') {
        toastr.error("Name field is required.");
        return false;
    }
    else if (name.length < 3 || name.length > 30)
    {
        toastr.error("Name length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!name.match(Nameregex))
    {
        toastr.error(" Name should contain only alphabetic characters");
        return false;
    }
    else if (contactEmail == "") {
       
        toastr.error("Email field is required.");
        return false;
    }
    else if (!contactEmail.match(Emailregex))
    {
        toastr.error("invalid email filed");
        return false;
    }
    
    else if (subject == '') {
       
        toastr.error("Subject field is required.");
        return false;
    }
    else if (subject.length < 3 || subject.length > 249)
    {
        toastr.error("Subject length should be between minlength 3 and maxlength 250");
        return false;
    }
    else if (!subject.match(messageregex)) {
        toastr.error(" subject should contain only alphabetic characters");
        return false;
    }
    else if (Message == '') {
        
        toastr.error("Message field is required.");
        return false;
    }
    else if (Message.length < 3 || Message.length > 249) {
        toastr.error("Message length should be between minlength 3 and maxlength 250");
        return false;
    }
    else if (!Message.match(messageregex)) {
        toastr.error(" Message should contain only alphabetic characters");
        return false;
    }
   // return true;
   
}
