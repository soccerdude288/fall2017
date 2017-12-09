package com.taylorearl.movietracker;

import android.app.Activity;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

public class MovieDetailActivity extends AppCompatActivity {
    MovieDetailResponse details;
    public void setDetails(MovieDetailResponse md){
        details = md;
    }
    Activity me = this;
    boolean isAdding = true;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_movie_detail);
        Log.d("testing", "Start on create detail view");
        setDetails((MovieDetailResponse)getIntent().getSerializableExtra("MOVIE"));
        DatabaseHelper dbhelp = new DatabaseHelper(this);
        isAdding = !dbhelp.doesMovieExist(details.id);
        if(isAdding == false){
            FloatingActionButton fab = (FloatingActionButton) this.findViewById(R.id.fab_action);
            fab.setImageResource(R.drawable.ic_remove_black_24dp);
        }

    }

    private void toggleButton() {
        FloatingActionButton fab = (FloatingActionButton) this.findViewById(R.id.fab_action);
        //set button to remove
        if(isAdding == false){
            isAdding = true;
            fab.setImageResource(R.drawable.ic_add_white_24dp);
        }
        //set button to add
        else{
            isAdding = false;
            fab.setImageResource(R.drawable.ic_remove_black_24dp);
        }
    }


    @Override
    public void onStart() {
        super.onStart();
        Log.d("testing", "OnStart detail view");
        Activity RootView = this;
        final Toolbar toolbar = (Toolbar)RootView.findViewById(R.id.toolbar);
        //Used to set the title to the movie title
        //For now going to leave this out
        //toolbar.setTitle(details.title);
        this.setTheme(R.style.AppTheme_NoActionBar);
        this.getWindow().addFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_NAVIGATION);
        this.setSupportActionBar(toolbar);
        if (this.getSupportActionBar() != null) {
            this.getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }
        FloatingActionButton fab = (FloatingActionButton) RootView.findViewById(R.id.fab_action);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatabaseHelper dbhelp = new DatabaseHelper(me);
                if(isAdding == true) {
                    dbhelp.insertMovie(details);
                    toggleButton();
                }
                else{
                    toggleButton();
                    dbhelp.deleteOneMovie(details.id);
                }
            }
        });
        ImageView backDrop = (ImageView)this.findViewById(R.id.movie_backdrop);
        ImageView posterImage = (ImageView)this.findViewById(R.id.movideDeatilPoster);
        Picasso.with(this).load("http://image.tmdb.org/t/p/w500/" + details.backdrop_path).resize(0, 140).into(backDrop);
        Picasso.with(this).load("http://image.tmdb.org/t/p/w500/" + details.poster_path).into(posterImage);
        TextView title = (TextView)RootView.findViewById(R.id.movieDetailTitle);
        TextView runtime = (TextView)RootView.findViewById(R.id.movieDetailRunTime);
        TextView releaseDate = (TextView)RootView.findViewById(R.id.movieDetailReleaseDate);
        TextView rating = (TextView)RootView.findViewById(R.id.movieDetailRating);
        TextView tagline = (TextView)RootView.findViewById(R.id.movieDetailTagLine);
        TextView overview = (TextView)RootView.findViewById(R.id.movieDetailOverview);
        TextView revenue = (TextView)RootView.findViewById(R.id.movieDetailRevenue);
        TextView prodCompanies = (TextView)RootView.findViewById(R.id.movieDetailProductionComp);

        title.setText(details.title);
        runtime.setText(details.runtime);
        releaseDate.setText(details.release_date);
        rating.setText(details.vote_average + "/10");
        tagline.setText(details.tagline);
        revenue.setText("$" + details.revenue);
        overview.setText(details.overview);
        prodCompanies.setText(details.getProductionCompanies());



    }
}
