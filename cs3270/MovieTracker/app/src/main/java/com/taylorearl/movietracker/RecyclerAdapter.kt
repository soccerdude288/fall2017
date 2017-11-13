package com.taylorearl.movietracker

import android.content.Intent
import android.support.v7.widget.RecyclerView
import android.util.Log
import android.view.View
import android.view.ViewGroup
import com.squareup.picasso.Picasso
import kotlinx.android.synthetic.main.cardview.view.*

/**
 * Created by taylor on 11/9/17.
 */
class RecyclerAdapter (private val movies: ArrayList<Movies>) : RecyclerView.Adapter<RecyclerAdapter.MovieHolder>()  {
    override fun getItemCount(): Int {
        return movies.size;
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerAdapter.MovieHolder{
        val inflatedView = parent.inflate(R.layout.cardview, false)
        return MovieHolder(inflatedView)
    }

    override fun onBindViewHolder(holder: RecyclerAdapter.MovieHolder, position: Int) {
        val itemMovie = movies[position]
        holder.bindMovie(itemMovie)
    }
    class MovieHolder(v: View) : RecyclerView.ViewHolder(v), View.OnClickListener {
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
            val context = itemView.context
            //val showMovieIntent = Intent(context, PhotoActivity::class.java)
            //showMovieIntent.putExtra(PHOTO_KEY, photo)
            //context.startActivity(showMovieIntent)
        }

        companion object {
            //5
            private val MOVIE_KEY = "MOVIE"
        }

        fun bindMovie(movie: Movies) {
            this.movie = movie
            Picasso.with(view.context).load(movie.posterURL).into(view.imageView2)
            view.movieTitle.text = movie.title
            view.movietagline.text = movie.tagLine
            view.movieReleaseDate.text = movie.releaseDate
            view.movieRating.text = movie.rating
            view.movieGenre.text = movie.genre
        }
    }
}