package com.taylorearl.movietracker

import android.content.Context
import android.content.Intent
import android.support.v4.app.Fragment
import android.support.v7.widget.RecyclerView
import android.util.Log
import android.view.View
import android.view.ViewGroup
import com.squareup.picasso.Picasso
import kotlinx.android.synthetic.main.cardview.view.*

/**
 * Created by taylor on 11/9/17.
 */
class RecyclerAdapter (private val movies: ArrayList<Movies>, private val frag: Fragment) : RecyclerView.Adapter<RecyclerAdapter.MovieHolder>()  {
    override fun getItemCount(): Int {
        return movies.size;
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerAdapter.MovieHolder{
        val inflatedView = parent.inflate(R.layout.cardview, false)

        return MovieHolder(inflatedView, frag)
    }

    override fun onBindViewHolder(holder: RecyclerAdapter.MovieHolder, position: Int) {
        val itemMovie = movies[position]
        holder.bindMovie(itemMovie)
    }
    class MovieHolder(v: View, private val frag: Fragment) : RecyclerView.ViewHolder(v), View.OnClickListener {
        //2
        private var view: View = v
        private var movie: Movies? = null

        //3
        init {
            v.setOnClickListener(this)
        }

        //4
        override fun onClick(v: View) {
            Log.d("RecyclerView", "CLICK!")
            var m = this.movie
            var api = TheMovieDBAPI();
            api.setSearchParams(m!!.id)
            val moviedetails = api.movieDetails().execute("")
            while(!api.hasResults){}
            val movieDetails = api.resultPage
            val ma = frag.activity as MainActivity
            ma.showMovieDetails(movieDetails)
        }

        companion object {
            //5
            private val MOVIE_KEY = "MOVIE"
        }

        fun bindMovie(movie: Movies) {
            this.movie = movie
            Picasso.with(view.context).load("http://image.tmdb.org/t/p/w500/" + movie.poster_path).into(view.imageView2)
            view.movieTitle.text = movie.title
            view.movieReleaseDate.text = movie.release_date
            view.movieRating.text = movie.vote_average + "/10"
            view.movieGenre.text = "";
        }
    }
}

