package com.taylorearl.movietracker

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import kotlinx.android.synthetic.main.fragment_home.*

class MyStuff : AppCompatActivity() {
    private lateinit var linearLayoutManager: LinearLayoutManager
    private lateinit var adapter: RecyclerAdapter
    private val lastVisibleItemPosition: Int
        get() = linearLayoutManager.findLastVisibleItemPosition()
    private var movieList: ArrayList<Movies> = ArrayList()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_my_stuff)
    }

    override fun onResume() {
        super.onResume()
        val dbHelp = DatabaseHelper(this, "Movies", null, 1)
        //loadingPanel.setVisibility(View.VISIBLE)
        val movieList = dbHelp.allMovies;
        //loadingPanel.setVisibility(View.GONE)

        linearLayoutManager = LinearLayoutManager(this)
        mainRecView.layoutManager = linearLayoutManager
        adapter = RecyclerAdapter(api.movieList as ArrayList<Movies>, this)
        mainRecView.adapter = adapter
        setRecyclerViewScrollListener()

    }

    private fun setRecyclerViewScrollListener() {
        mainRecView.addOnScrollListener(object : RecyclerView.OnScrollListener() {
            override fun onScrollStateChanged(recyclerView: RecyclerView?, newState: Int) {
                super.onScrollStateChanged(recyclerView, newState)
                val totalItemCount = recyclerView!!.layoutManager.itemCount
                /*
                if (!imageRequester.isLoadingData && totalItemCount == lastVisibleItemPosition + 1) {
                    requestPhoto()
                }
                */
            }
        })
    }

}
