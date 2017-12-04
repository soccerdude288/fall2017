package com.taylorearl.movietracker;


import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteCursor;
import android.graphics.Movie;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.ImageView;

import com.squareup.picasso.Picasso;


/**
 * A simple {@link Fragment} subclass.
 */
public class MovieDetails extends Fragment {


    MovieDetailResponse details;
    public MovieDetails() {
        // Required empty public constructor
    }

    public void setDetails(MovieDetailResponse md){
        details = md;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View RootView = inflater.inflate(R.layout.fragment_movie_details, container, false);
        MainActivity ma = (MainActivity)getActivity();
        //ma.setTheme(R.style.AppTheme_NoActionBar);
        //ma.getWindow().addFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_NAVIGATION);


        //ImageView image_scrolling_top = (ImageView)getView().findViewById(R.id.movie_backdrop);
        //Glide.with(this).load(R.drawable.material_design_3).fitCenter().into(image_scrolling_top);

        return RootView;
    }

    @Override
    public void onStart() {
        super.onStart();
        View RootView = getView();
        MainActivity ma = (MainActivity)getActivity();
        Toolbar toolbar = (Toolbar)RootView.findViewById(R.id.toolbar);
        ma.getSupportActionBar().hide();
        ma.setSupportActionBar(toolbar);
        if (ma.getSupportActionBar() != null) {
            ma.getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }

        FloatingActionButton fab = (FloatingActionButton) RootView.findViewById(R.id.fab_action);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MainActivity ma = (MainActivity)getActivity();
                DatabaseHelper dbhelp = new DatabaseHelper(ma, "Movies", null, 1);
                dbhelp.insertMovie(details);
            }
        });
        ImageView backDrop = (ImageView)getView().findViewById(R.id.movie_backdrop);
        //ImageView posterImage = (ImageView)getView().findViewById(R.id.posterImage);
        Picasso.with(getActivity()).load("http://image.tmdb.org/t/p/w500/" + details.backdrop_path).into(backDrop);
        //Picasso.with(getActivity()).load("http://image.tmdb.org/t/p/w500/" + details.poster_path).into(posterImage);
    }
}

