package com.taylorearl.movietracker;

import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.jetbrains.annotations.NotNull;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import javax.net.ssl.HttpsURLConnection;

/**
 * Created by taylor on 11/11/17.
 */

public class TheMovieDBAPI {
    private String URL_SCHEME = "https://";
    private String URL_AUTHORITY = "api.themoviedb.org/3";
    private String URL_PATH_SEARCH = "/search";
    private String URL_PATH_MOVIE = "/movie";
    private String URL_PARAM ="?";
    private String URL_QUERY_PARAM_API_KEY = "api_key=";
    private String URL_QUERY = "query=";
    private String URL_PARAM_APPEND = "&";
    private String URL_PARAM_PAGE = "page=";
    private String URL_PARAM_PAGE_VALUE ="1";
    private String URL_QUERY_VALUE_API_KEY = Authentication.KEY;
    private String URL_PATH_POPULAR ="/popular";
    public String rtnValue = "";
    private String URL_PATH = "";
    private String searchValue = "";
    public List<Movies> movieList = new ArrayList<>();
    public boolean hasResults = false;
    public MovieDetailResponse resultPage;

    public void setSearchParams(String searchValue){
        this.URL_PATH = URL_PATH_MOVIE;
        this.searchValue = searchValue;
    }


    public void setPopularSearchParams(){
        this.URL_PATH = URL_PATH_MOVIE;
    }

    public class movieSearch extends AsyncTask<String, Integer, String>{

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In do in background api");
            String rawJson = "";
            StringBuilder urlString = new StringBuilder();
            urlString.append(URL_SCHEME);
            urlString.append(URL_AUTHORITY);
            urlString.append(URL_PATH_SEARCH);
            urlString.append(URL_PATH);
            urlString.append(URL_PARAM);
            urlString.append(URL_QUERY_PARAM_API_KEY);
            urlString.append(URL_QUERY_VALUE_API_KEY);
            urlString.append(URL_PARAM_APPEND);
            urlString.append(URL_PARAM_PAGE);
            urlString.append(URL_PARAM_PAGE_VALUE);
            urlString.append(URL_PARAM_APPEND);
            urlString.append(URL_QUERY);
            try {
                urlString.append(URLEncoder.encode(searchValue, "UTF-8"));
                URL url = new URL(urlString.toString());
                HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                conn.setRequestMethod("GET");
                conn.connect();
                Log.d("taylorTest", "In do in background api: Connection Made");
                int status = conn.getResponseCode();
                switch (status){
                    case 200:
                    case 201:
                        BufferedReader br =
                                new BufferedReader(new InputStreamReader(conn.getInputStream()));
                        rawJson = br.readLine();
                        Log.d("taylorTest", "ras JSON String Length = " + rawJson.length());
                        Log.d("taylorTest", "ras JSON first 256 chars = " + rawJson.substring(0, 256));
                        Log.d("taylorTest", "ras JSON last 256 chars = " + rawJson.substring(rawJson.length() - 256, rawJson.length()));
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            }catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
            try{
                Log.d("taylorTest", "Attempting to build movie list");
                MovieResponse resultPage = parseMovies(rawJson);
                for(Movies movie:resultPage.results){
                    Log.d("taylorTest", "*** Movie Name: " + movie.title);
                    movieList.add(movie);
                }
                Log.d("taylorTest", "Movie List Built");
                hasResults = true;
                int count = movieList.size();
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return rawJson;
        }

        @Override
        protected void onPostExecute(String s){
            super.onPostExecute(s);
            /*
            try{
                MovieResponse resultPage = parseMovies(s);
                    for(Movies movie:resultPage.results){
                        movieList.add(movie);
                    }
                    hasResults = true;
                    int count = movieList.size();
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            */
        }

        public MovieResponse parseMovies(String rawJSON){
            GsonBuilder gsonb = new GsonBuilder();
            Gson gson = gsonb.create();
            MovieResponse movies = new MovieResponse();
            try{
                movies = gson.fromJson(rawJSON, MovieResponse.class);
                //Log.d("taylorTest", "number of assignments returned is: " + movies.length);
                //Log.d("taylorTest", "First Course returned is: " + movies.indexOf(0).title);
            } catch(Exception e){
                Log.d("taylorTest", e.getMessage());
            }

            return movies;
        }
    }

    public class movieDetails extends AsyncTask<String, Integer, String>{

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In do in background api");
            String rawJson = "";
            StringBuilder urlString = new StringBuilder();
            urlString.append(URL_SCHEME);
            urlString.append(URL_AUTHORITY);
            urlString.append(URL_PATH);
            urlString.append("/"+searchValue);
            urlString.append(URL_PARAM);
            urlString.append(URL_QUERY_PARAM_API_KEY);
            urlString.append(URL_QUERY_VALUE_API_KEY);
            urlString.append(URL_PARAM_APPEND);
            urlString.append("language=en-US");
            try {
                urlString.append(URLEncoder.encode(searchValue, "UTF-8"));
                URL url = new URL(urlString.toString());
                HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                conn.setRequestMethod("GET");
                conn.connect();
                Log.d("taylorTest", "In do in background api: Connection Made");
                int status = conn.getResponseCode();
                switch (status){
                    case 200:
                    case 201:
                        Map<String, List<String>> map = conn.getHeaderFields();
                        Log.d("taylorTest", "X-RateLimit-Limit - " + map.get("X-RateLimit-Limit"));
                        BufferedReader br =
                                new BufferedReader(new InputStreamReader(conn.getInputStream()));
                        rawJson = br.readLine();
                        Log.d("taylorTest", "ras JSON String Length = " + rawJson.length());
                        Log.d("taylorTest", "ras JSON first 256 chars = " + rawJson.substring(0, 256));
                        Log.d("taylorTest", "ras JSON last 256 chars = " + rawJson.substring(rawJson.length() - 256, rawJson.length()));
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            }catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
            try{
                Log.d("taylorTest", "Attempting to build movie list");
                resultPage = parseMovies(rawJson);
                Log.d("taylorTest", "Movie List Built");
                hasResults = true;
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return rawJson;
        }

        @Override
        protected void onPostExecute(String s){
            super.onPostExecute(s);
        }

        public MovieDetailResponse parseMovies(String rawJSON){
            GsonBuilder gsonb = new GsonBuilder();
            Gson gson = gsonb.create();
            MovieDetailResponse movies = new MovieDetailResponse();
            try{
                movies = gson.fromJson(rawJSON, MovieDetailResponse.class);
                //Log.d("taylorTest", "number of assignments returned is: " + movies.length);
                //Log.d("taylorTest", "First Course returned is: " + movies.indexOf(0).title);
            } catch(Exception e){
                Log.d("taylorTest", e.getMessage());
            }

            return movies;
        }
    }



    public class popularSearch extends AsyncTask<String, Integer, String>{

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In do in background api");
            String rawJson = "";
            StringBuilder urlString = new StringBuilder();
            urlString.append(URL_SCHEME);
            urlString.append(URL_AUTHORITY);
            urlString.append(URL_PATH);
            urlString.append(URL_PATH_POPULAR);
            urlString.append(URL_PARAM);
            urlString.append(URL_QUERY_PARAM_API_KEY);
            urlString.append(URL_QUERY_VALUE_API_KEY);
            urlString.append(URL_PARAM_APPEND);
            urlString.append(URL_PARAM_PAGE);
            urlString.append(URL_PARAM_PAGE_VALUE);
            urlString.append(URL_PARAM_APPEND);
            urlString.append("language=en-US");
            try {
                urlString.append(URLEncoder.encode(searchValue, "UTF-8"));
                URL url = new URL(urlString.toString());
                HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                conn.setRequestMethod("GET");
                conn.connect();
                Log.d("taylorTest", "In do in background api: Connection Made");
                int status = conn.getResponseCode();
                switch (status){
                    case 200:
                    case 201:

                        Map<String, List<String>> map = conn.getHeaderFields();
                        Log.d("taylorTest", "X-RateLimit-Limit - " + map.get("X-RateLimit-Limit"));
                        BufferedReader br =
                                new BufferedReader(new InputStreamReader(conn.getInputStream()));
                        rawJson = br.readLine();
                        Log.d("taylorTest", "ras JSON String Length = " + rawJson.length());
                        Log.d("taylorTest", "ras JSON first 256 chars = " + rawJson.substring(0, 256));
                        Log.d("taylorTest", "ras JSON last 256 chars = " + rawJson.substring(rawJson.length() - 256, rawJson.length()));
                }
            } catch (MalformedURLException e) {
                e.printStackTrace();
            }catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
            try{
                Log.d("taylorTest", "Attempting to build movie list");
                MovieResponse resultPage = parseMovies(rawJson);
                for(Movies movie:resultPage.results){
                    Log.d("taylorTest", "*** Movie Name: " + movie.title);
                    movieList.add(movie);
                }
                Log.d("taylorTest", "Movie List Built");
                hasResults = true;
                int count = movieList.size();
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return rawJson;
        }

        @Override
        protected void onPostExecute(String s){
            super.onPostExecute(s);
        }

        public MovieResponse parseMovies(String rawJSON){
            GsonBuilder gsonb = new GsonBuilder();
            Gson gson = gsonb.create();
            MovieResponse movies = new MovieResponse();
            try{
                movies = gson.fromJson(rawJSON, MovieResponse.class);
                //Log.d("taylorTest", "number of assignments returned is: " + movies.length);
                //Log.d("taylorTest", "First Course returned is: " + movies.indexOf(0).title);
            } catch(Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return movies;
        }
    }
}
