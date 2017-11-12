package com.taylorearl.movietracker;

/**
 * Created by taylor on 11/11/17.
 */

public class Movies {
    private String title;
    private String tagLine;
    private String releaseDate;
    private String rating;
    private String genre;

    public String getPosterURL() {
        return posterURL;
    }

    public void setPosterURL(String posterURL) {
        this.posterURL = posterURL;
    }

    private String posterURL;

    public Movies(String vTitle, String vTagLine, String vReleaseDate, String vRating, String vGenre, String vPosterURL){
        title = vTitle;
        tagLine = vTagLine;
        releaseDate = vReleaseDate;
        rating = vRating;
        genre = vGenre;
        posterURL = vPosterURL;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getTagLine() {
        return tagLine;
    }

    public void setTagLine(String tagLine) {
        this.tagLine = tagLine;
    }

    public String getReleaseDate() {
        return releaseDate;
    }

    public void setReleaseDate(String releaseDate) {
        this.releaseDate = releaseDate;
    }

    public String getRating() {
        return rating;
    }

    public void setRating(String rating) {
        this.rating = rating;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }
}
