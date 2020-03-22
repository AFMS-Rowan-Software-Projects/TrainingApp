var ViewModel = function () {
    var self = this;
    self.courses = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    //self.categories = ko.observableArray();
    //self.newCourse = {
    //    CategoryId: ko.observable(),
    //    CourseName: ko.observable(),
    //    CourseDesc: ko.observable(),
    //    PreReqs: ko.observable(),
    //    Tuition: ko.observable(),
    //    Fees: ko.observable(),
    //    FeeDesc: ko.observable(),
    //    Active: ko.observable()
    //}

    var coursesUri = '/api/courses/';
    //var categoriesUri = '/api/categories/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCourses() {
        ajaxHelper(coursesUri, 'GET').done(function (data) {
            self.courses(data);
        });
    }

    self.getCourseDetail = function (item) {
        ajaxHelper(coursesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    //function getCategories() {
    //    ajaxHelper(categoriesUri, 'GET').done(function (data) {
    //        self.categories(data);
    //    });
    //}

    //self.addCourse = function (formElement) {
    //    var course = {
    //        CategoryId: self.newCourse.Category().Id,
    //        CourseName: self.newCourse.CourseName(),
    //        CourseDesc: self.newCourse.CourseDesc(),
    //        PreReqs: self.newCourse.PreReqs(),
    //        Tuition: self.newCourse.Tuition(),
    //        Fees: self.newCourse.Fees(),
    //        FeeDesc: self.newCourse.FeeDesc(),
    //        Active: self.newCourse.Active()
    //    };

    //    ajaxHelper(coursesUri, 'POST', course).done(function (item) {
    //        self.courses.push(item);
    //    });
    //}

    // Fetch the initial data.
    //getAllCourses();
    getCategories();
};

ko.applyBindings(new ViewModel());