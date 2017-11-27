package com.taylorearl.movietracker;


import android.graphics.Movie;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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
        return inflater.inflate(R.layout.fragment_movie_details, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();
        ImageView backDrop = (ImageView)getView().findViewById(R.id.backdropImage);
        ImageView posterImage = (ImageView)getView().findViewById(R.id.posterImage);
        Picasso.with(getActivity()).load("http://image.tmdb.org/t/p/w500/" + details.backdrop_path).into(backDrop);
        Picasso.with(getActivity()).load("http://image.tmdb.org/t/p/w500/" + details.poster_path).into(posterImage);
    }
}
