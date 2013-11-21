var app = app || {};

app.Book = Backbone.Model.extend({
    defaults: {
        coverImage: "../../Images/placeholder.png",
        title: "No title",
        author: "Unknown",
        releaseDate: "Unknown",
        keywords: "None"
    },
    //url:'/books',
    
    parse: function(response) {
        response.coverImage = response.CoverImage;
        response.title = response.Title;
        response.author = response.Author;
        response.releaseDate = response.ReleaseDate;
        response.keywords = response.Keywords;
        response.id = response.Id;
        return response;
    }
});
