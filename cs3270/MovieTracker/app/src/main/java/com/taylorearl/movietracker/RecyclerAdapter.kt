package com.taylorearl.movietracker

import android.support.v7.widget.RecyclerView
import android.util.Log
import android.view.View
import android.view.ViewGroup
import kotlinx.android.synthetic.main.recyclerview_item_row.view.*

/**
 * Created by taylor on 11/9/17.
 */
class RecyclerAdapter (private val movies: ArrayList<Movies>) : RecyclerView.Adapter<RecyclerAdapter.MovieHolder>()  {
    override fun getItemCount(): Int {
        return movies.size;
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerAdapter.MovieHolder{
        val inflatedView = parent.inflate(R.layout.recyclerview_item_row, false)
        return MovieHolder(inflatedView)
    }

    override fun onBindViewHolder(holder: RecyclerAdapter.MovieHolder, position: Int) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
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
        }

        companion object {
            //5
            private val MOVIE_KEY = "MOVIE"
        }
    }
}