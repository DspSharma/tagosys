

function addUpdateSystemSetting() {
    let name = $('#name').val();
    let email = $('#email').val();
    let mobile = $('#mobile').val();
    let registeredOfficeAddress = $('#registeredOfficeAddress').val();
    let operationalOfficeAddress = $('#operationalOfficeAddress').val();
    let image = $('#imagefiles').val();

    var Emailregex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var Nameregex = /\b.*[a-zA-Z ].\b/;
    var mobileregex = /^[789]\d{9}$/; 
    $(".error").remove();

    if (name == '') {
        toastr.error("name field is required");
        return false;
    }
    else if (name.length < 3 || name.length > 29) {
        toastr.error("Name length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!name.match(Nameregex)) {
        toastr.error("Name should contain only alphabetic characters");
        return false;
    }
    else if (email == '') {
        toastr.error("Email field is required");
        return false;
    }
    else if (!email.match(Emailregex)) {
        toastr.error("invalid email filed");
        return false;
    }
    else if (mobile == '') {
        toastr.error("Mobile field is required");
        return false;
    }
    else if (mobile.length > 10 || mobile.length < 10) {
        toastr.error("Mobile number should be 10 digits");
        return false;
    }
    else if (!mobile.match(mobileregex)) {
        toastr.error("invalid phone number");
        return false;
    }
    else if (registeredOfficeAddress == '') {
        toastr.error("registeredOfficeAddress field is required");
        return false;
    }
    else if (operationalOfficeAddress == '') {
        toastr.error("operationalOfficeAddress field is required");
        return false;
    }
    else if (image == '' && oldImage == '') {
        toastr.error("Image field is required.");
        return false;
    }
}


function addUpdateProject() {
  
    let projectName = $('#projectName').val();
    let description = $('#description').val();
    let projectUrl = $('#projectUrl').val();
    let image = $('#imagefiles').val();
    var Nameregex = /^[a-zA-Z][a-zA-Z ]*$/;
    var message = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;
    $(".error").remove();

    if (projectName == '') {

        toastr.error("projectName field is required");
        return false;
    }
    else if (projectName.length < 3 || projectName.length > 30) {
        toastr.error("projectName length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!projectName.match(Nameregex))
    {
        toastr.error("projectName should contain only alphabetic characters");
        return false;
    }
    else if (description == '') {
        toastr.error("description field is required");
        return false;
    }
    else if (description.length < 3 || description.length > 999) {
        toastr.error("description length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!description.match(message))
    {
        toastr.error("description should contain only alphabetic characters");
        return false;
    }
    else if (projectUrl == '')
    {
        toastr.error("projectUrl field is required");
        return false;
    }
    else if (image == "" && oldImage == "") {
        toastr.error("Image Field is Required.");
        return false;
    }
}

function addUpdateClient() {
    let name = $('#name').val();
    let country = $('#country').val();
    let tittle = $('#tittle').val();
    let description = $('#description').val();
    let rating = $('#rating').val();
    let image = $('#imagefiles').val();

    var Nameregex = /\b.*[a-zA-Z ].\b/;
    var message = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;
    $(".error").remove();

    if (name == '') {
        toastr.error("name field is required");
        return false;
    }
    else if (name.length < 3 || name.length > 30) {
        toastr.error("name length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!name.match(Nameregex)) {
        toastr.error("Name should contain only alphabetic characters");
        return false;
    }
    else if (country == '') {
        toastr.error("country field is required");
        return false;
    }
    else if (country.length < 3 || country.length > 30) {
        toastr.error("country length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!country.match(Nameregex)) {
        toastr.error("country should contain only alphabetic characters");
        return false;
    }
    else if (tittle == '') {
        toastr.error("tittle field is required");
        return false;
    }
    else if (tittle.length < 3 || tittle.length > 99) {
        toastr.error("tittle length should be between minlength 3 and maxlength 100");
        return false;
    }
    else if (!tittle.match(message)) {
        toastr.error("tittle should contain only alphabetic characters");
        return false;
    }
    else if (description == '') {
        toastr.error("description field is required");
        return false;
    }
    else if (description.length < 3 || description.length > 2000) {
        toastr.error("description length should be between minlength 3 and maxlength 2000");
        return false;
    }
    //else if (!description.match(message))
    //{
    //    toastr.error("description should contain only alphabetic characters");
    //    return false;
    //}
    else if (rating == '') {
        toastr.error("Rating field is required");
        return false;
    }
    else if (image == "" && oldImage == "") {
        toastr.error("Image Field is Required.");
        return false;
    }
}

function addUpdateTeam() {
    
    let name = $('#name').val();
    let professionField = $('#professionField').val();
    let dob = $('#dob').val();
    let city = $('#city').val();
    let state = $('#state').val();
    let address = $('#address').val();
    let email = $('#email').val();
    let mobile = $('#mobile').val();
    let image = $('#imagefiles').val();

    var numbers = /^[0-9]+$/;
    var Emailregex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var Nameregex = /\b.*[a-zA-Z ].\b/;
    var message = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;

    $(".error").remove();

    if (name == '') {
        toastr.error("name field is required");
        return false;
    }
    else if (name.length < 3 || name.length > 30) {
        toastr.error("name length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!name.match(Nameregex)) {

        toastr.error("Name should contain only alphabetic characters");
        return false;
    }
    else if (professionField == '') {
        toastr.error("professionField field is required");
        return false;
    }
    else if (professionField.length < 2 || professionField.length > 30) {
        toastr.error("professionField length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!professionField.match(Nameregex)) {

        toastr.error("professionField should contain only alphabetic characters");
        return false;
    }
    else if (dob == '') {
        toastr.error("dob field is required");
        return false;
    }
    else if (city == '') {
        toastr.error("City field is required");
        return false;
    }
    else if (city.length < 3 || city.length > 30) {
        toastr.error("City length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!city.match(Nameregex)) {

        toastr.error("city should contain only alphabetic characters");
        return false;
    }
    else if (state == '') {
        toastr.error("State field is required");
        return false;
    }
    else if (state.length < 3 || state.length > 30) {
        toastr.error("state length should be between minlength 3 and maxlength 30");
        return false;
    }
    else if (!state.match(Nameregex)) {

        toastr.error("state should contain only alphabetic characters");
        return false;
    }
    else if (address == '') {
        toastr.error("address field is required");
        return false;
    }
    else if (address.length < 3 || address.length > 100) {
        toastr.error("address length should be between minlength 3 and maxlength 100");
        return false;
    }
    else if (!address.match(message)) {

        toastr.error("address should contain only alphabetic characters");
        return false;
    }
    else if (email == '') {
        toastr.error("email field is required");
        return false;
    }

    else if (!email.match(Emailregex)) {

        toastr.error("invalid email field");
        return false;
    }
    else if (mobile == '') {
        toastr.error("mobile field is required");
        return false;
    }
    else if (mobile.length > 10 || mobile.length < 10) {
        toastr.error("Mobile number should be 10 digits");
        return false;
    }
    else if (!mobile.match(numbers)) {
        toastr.error("invalid phone number");
        return false;
    }
    else if (image == "" && oldImage == "") {
        toastr.error("Image Field is Required.");
        return false;
    }

}

function addUpdatePage() {
    let tittle = $('#tittle').val();
    var Nameregex = /\b.*[a-zA-Z ].\b/;

    $(".error").remove();

    if (tittle == '') {
        toastr.error("tittle field is required");
        return false;
    }
    else if (tittle.length < 3 || tittle.length > 40) {
        toastr.error("Tittle length should be between minlength 3 and maxlength 40");
        return false;
    }
    else if (!tittle.match(Nameregex)) {
        toastr.error("tittle should contain only alphabetic characters");
        return false;
    }
}

function addUpdatePost() {
    let tittle = $('#tittle').val();
    let shortDescription = $('#shortDescription').val();
    let image = $('#imagefiles').val();
   // var message = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;

    $(".error").remove();
    if (tittle == '') {
        toastr.error("tittle field is required");
        return false;
    }
    else if (tittle.length < 3 || tittle.length > 199) {
        toastr.error("Tittle length should be between minlength 3 and maxlength 200");
        return false;
    }
    //else if (!tittle.match(message))
    //{
    //    toastr.error("tittle should contain only alphabetic characters");
    //    return false;
    //}
    else if (shortDescription == '') {
        toastr.error("shortDescription field is required");
        return false;
    }
    else if (shortDescription.length < 3 || shortDescription.length > 2000) {
        toastr.error("shortDescription length should be between minlength 3 and maxlength 2000");
        return false;
    }
    else if (!shortDescription.match(message))
    {
        toastr.error("shortDescription should contain only alphabetic characters");
        return false;
    }
    else if (image == "" && oldImage == "") {
        toastr.error("Image Field is Required.");
        return false;
    }
}

function addUpdatePostDescription() {
    let tittle = $('#tittle').val();
    let description = $('#description').val();
    let image = $('#imagefiles').val();

    var message = /^[a-zA-Z][a-zA-Z0-9\s.,#-]*$/;

    $(".error").remove();
    if (tittle == '') {
        toastr.error("tittle field is required");
        return false;
    }
    else if (tittle.length < 3 || tittle.length > 249) {
        toastr.error("Tittle length should be between minlength 3 and maxlength 250");
        return false;
    }
    else if (!tittle.match(message)) {
        toastr.error("tittle should contain only alphabetic characters");
        return false;
    }
    else if (description == '') {
        toastr.error("description field is required");
        return false;
    }
    else if (description.length < 3 || description.length > 3000) {
        toastr.error("description length should be between minlength 3 and maxlength 3000");
        return false;
    }
    //else if (!description.match(message)) {
    //    toastr.error("description should contain only alphabetic characters");
    //    return false;
    //}
    else if (image == "" && oldImage == "") {
        toastr.error("Image Field is Required.");
        return false;
    }
}








