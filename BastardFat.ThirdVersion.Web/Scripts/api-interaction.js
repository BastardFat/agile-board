var apiInteraction = {

    peoplesApi : "/PeopleApi",
    studyPlacesApi: "/StudyPlace",
    workPlacesApi: "/WorkPlace",
    
    getPeoples : function (callback, errorCallback) {
        this.getRequest(this.peoplesApi, callback, errorCallback);
    },
    addPeople : function (people, callback, errorCallback) {
        this.bodiedRequest(this.peoplesApi, people, "POST", callback, errorCallback);
    },
    updatePeople: function (people, callback, errorCallback) {
        this.bodiedRequest(this.peoplesApi, people, "PUT", callback, errorCallback);
    },
    deletePeople: function (people, callback, errorCallback) {
        this.bodiedRequest(this.peoplesApi, people, "DELETE", callback, errorCallback);
    },

    getStudyPlaces: function (callback, errorCallback) {
        this.getRequest(this.studyPlacesApi, callback, errorCallback);
    },
    addStudyPlace: function (studyPlace, callback, errorCallback) {
        this.bodiedRequest(this.studyPlacesApi, studyPlace, "POST", callback, errorCallback);
    },
    updateStudyPlace: function (studyPlace, callback, errorCallback) {
        this.bodiedRequest(this.studyPlacesApi, studyPlace, "PUT", callback, errorCallback);
    },
    deleteStudyPlace: function (studyPlace, callback, errorCallback) {
        this.bodiedRequest(this.studyPlacesApi, studyPlace, "DELETE", callback, errorCallback);
    },


    getWorkPlaces: function (callback, errorCallback) {
        this.getRequest(this.workPlacesApi, callback, errorCallback);
    },
    addWorkPlace: function (workPlace, callback, errorCallback) {
        this.bodiedRequest(this.workPlacesApi, workPlace, "POST", callback, errorCallback);
    },
    updateWorkPlace: function (workPlace, callback, errorCallback) {
        this.bodiedRequest(this.workPlacesApi, workPlace, "PUT", callback, errorCallback);
    },
    deleteWorkPlace: function (workPlace, callback, errorCallback) {
        this.bodiedRequest(this.workPlacesApi, workPlace, "DELETE", callback, errorCallback);
    },


    bodiedRequest : function (api, bodyObject, method, callback, errorCallback) {
        $.ajax({
            url: api,
            dataType: "json",
            type: method,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(bodyObject),
            error: function (xhr) {
                errorCallback(xhr);
            }
        }).done(function (result) {
            callback(result);
        });
    },

    getRequest: function(api, callback, errorCallback) {
        $.ajax({
            url: api,
            type: "GET",
            error: function (xhr) {
                errorCallback(xhr);
            }
        }).done(function (result) {
            callback(result);
        });
    }

}