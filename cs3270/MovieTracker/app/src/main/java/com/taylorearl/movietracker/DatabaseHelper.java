package com.taylorearl.movietracker;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by taylor on 11/9/17.
 */

public class DatabaseHelper extends SQLiteOpenHelper{
    private SQLiteDatabase database;

    public DatabaseHelper(Context context){
        super(context, "Movies", null,1);
    }

    //MOVIE
    //_id
    //title
    //dbID
    //genre
    //runtime
    //tagline
    //rating
    //poster
    //releaseDate


    public SQLiteDatabase open(){
        database = getWritableDatabase();
        return database;
    }

    public void close(){
        if(database != null){
            database.close();
        }
    }

    public long insertMovie(MovieDetailResponse m){
        long rowID = -1;

        ContentValues newMovie = new ContentValues();
        newMovie.put("title", m.title);
        newMovie.put("dbID", m.id);
        newMovie.put("genre", m.genres.toString());
        newMovie.put("runtime", m.runtime);
        newMovie.put("tagline", m.tagline);
        newMovie.put("rating", m.vote_average);
        newMovie.put("poster", m.poster_path);
        newMovie.put("releaseDate", m.release_date);

        if(open()!=null){
            rowID = database.insert("movies", null, newMovie);
            close();
        }
        return rowID;
    }

    public long updateMovie(MovieDetailResponse m, long _id){
        long rowID = -1;

        ContentValues newMovie = new ContentValues();
        newMovie.put("title", m.title);
        newMovie.put("dbID", m.id);
        newMovie.put("genre", m.genres.toString());
        newMovie.put("runtime", m.runtime);
        newMovie.put("tagline", m.tagline);
        newMovie.put("rating", m.vote_average);
        newMovie.put("poster", m.poster_path);
        newMovie.put("releaseDate", m.release_date);

        if(open()!=null){
            rowID = database.update("movies", newMovie, "_id=" + _id, null);
            close();
        }
        return rowID;
    }

    public List<Movies> getAllMovies(){
        Cursor cursor = null;
        ArrayList<Movies> movies = new ArrayList<Movies>();

        if(open() != null){
            Log.d("testing", "In getAllMovies");
            cursor = database.rawQuery("SELECT * FROM movies", null);
        }

        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            Movies movie = new Movies();
            //_id
            movie._id = cursor.getString(0);
            //title
            movie.title = cursor.getString(1);
            //dbID
            movie.id = cursor.getString(2);
            //genre
            //movie.genre_ids = cursor.getString(3);
            //runtime
            //movie.run = cursor.getString(4);
            //tagline
            //movie = cursor.getString(5);
            //rating
            movie.vote_average = cursor.getString(6);
            //poster
            movie.poster_path = cursor.getString(7);
            //releaseDate
            movie.release_date = cursor.getString(8);

            movies.add(movie);
            cursor.moveToNext();
        }


        return movies;
    }

    public Movies getOneMovie(String id){
        Cursor cursor = null;
        Movies movie = new Movies();
        if(open() != null){
            Log.d("testing", "In getOneMovie");
            cursor = database.rawQuery("SELECT * FROM movies WHERE dbID=" +id, null);
        }
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            //_id
            movie._id = cursor.getString(0);
            //title
            movie.title = cursor.getString(1);
            //dbID
            movie.id = cursor.getString(2);
            //genre
            //movie.genre_ids = cursor.getString(3);
            //runtime
            //movie.run = cursor.getString(4);
            //tagline
            //movie = cursor.getString(5);
            //rating
            movie.vote_average = cursor.getString(6);
            //poster
            movie.poster_path = cursor.getString(7);
            //releaseDate
            movie.release_date = cursor.getString(8);


            cursor.moveToNext();
        }
        return movie;
    }

    public boolean doesMovieExist(String id){
        Cursor cursor = null;
        Movies movie = new Movies();
        if(open() != null){
            Log.d("testing", "In getOneMovie");
            cursor = database.rawQuery("SELECT * FROM movies WHERE dbID=" +id, null);
        }
        if (!(cursor.moveToFirst()) || cursor.getCount() ==0){
            return false;
        }
        return true;
    }

    public void deleteOneMovie(String id) {
        long rowID = -1;
        if (open() != null) {
            Log.d("testing", "In deleteOneMovie");
            //cursor = database.rawQuery("DELETE FROM classes WHERE _id=" +id, null);
            rowID = database.delete("movies", "dbID=" + id, null);
            close();
        }
    }

    public Cursor getMovieID(long id){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getMovieID");
            cursor = database.rawQuery("SELECT * FROM movies WHERE _id=" +id, null);
        }
        return cursor;
    }

    public void dropMovies(){
        if(open() != null){
            String createQuery = "CREATE TABLE movies" +
                    "(_id integer primary key autoincrement," +
                    "title TEXT, dbID TEXT, genre TEXT, runtime TEXT, tagline TEXT, rating TEXT, poster TEXT, releaseDate TEXT);";
            String dropQuery = "DROP TABLE movies";
            database.execSQL(dropQuery);
            database.execSQL(createQuery);
            close();
        }
    }

    @Override
    public void onCreate(SQLiteDatabase db){
        Log.d("testing", "in onCreate dbhelper");
        String createQuery = "CREATE TABLE movies" +
                "(_id integer primary key autoincrement," +
                "title TEXT, dbID TEXT, genre TEXT, runtime TEXT, tagline TEXT, rating TEXT, poster TEXT, releaseDate TEXT);";
        db.execSQL(createQuery);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion){

    }
}
