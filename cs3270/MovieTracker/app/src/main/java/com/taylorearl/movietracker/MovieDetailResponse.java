package com.taylorearl.movietracker;

import java.util.List;

/**
 * Created by Taylor on 11/26/2017.
 */

public class MovieDetailResponse {
    protected String adult;
    protected String backdrop_path;
    protected BelongsToCollection belongs_to_collection;
    protected String budget;
    protected List<Genres> genres;
    protected String homepage;
    protected String id;
    protected String imdb_id;
    protected String original_language;
    protected String original_title;
    protected String overview;
    protected String popularity;
    protected String poster_path;
    protected List<ProdCompanies> production_companies;
    protected List<ProdCountries> production_countries;
    protected String release_date;
    protected String revenue;
    protected String runtime;
    protected List<SpokenLanguages> spoken_languages;
    protected String status;
    protected String tagline;
    protected String title;
    protected String video;
    protected String vote_average;
    protected String vote_count;

    private class BelongsToCollection{
        String id;
        String name;
        String poster_path;
        String backdrop_path;
    }
    private class Genres{
        String id;
        String name;
    }
    private class ProdCompanies{
        String name;
        String id;
    }
    private class ProdCountries{
        String iso_3166_1;
        String name;
    }
    private class SpokenLanguages{
        String iso_639_1;
        String name;
    }

}



