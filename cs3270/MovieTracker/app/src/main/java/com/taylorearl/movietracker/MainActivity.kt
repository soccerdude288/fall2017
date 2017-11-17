package com.taylorearl.movietracker

import android.os.Bundle
import android.support.design.widget.BottomNavigationView
import android.support.v7.app.AppCompatActivity
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import com.taylorearl.movietracker.R.id.mainRecView
import com.taylorearl.movietracker.R.id.navigation
import kotlinx.android.synthetic.main.activity_main.*
import android.support.v7.widget.GridLayoutManager

class MainActivity : AppCompatActivity() {
    private lateinit var linearLayoutManager: LinearLayoutManager
    private lateinit var adapter: RecyclerAdapter
    private val lastVisibleItemPosition: Int
        get() = linearLayoutManager.findLastVisibleItemPosition()
    private var movieList: ArrayList<Movies> = ArrayList()

    private val mOnNavigationItemSelectedListener = BottomNavigationView.OnNavigationItemSelectedListener { item ->
        when (item.itemId) {
            R.id.navigation_home -> {
                //message.setText(R.string.title_home)
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_stuff -> {
                //message.setText(R.string.title_myStuff)
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_search -> {
                supportFragmentManager
                        .beginTransaction()
                        .add(R.id.container, SearchFrag(), "searchFragment")
                        .addToBackStack(null)
                        .commit()
                //message.setText(R.string.title_search)
                return@OnNavigationItemSelectedListener true
            }
        }
        false
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        linearLayoutManager = LinearLayoutManager(this)
        mainRecView.layoutManager = linearLayoutManager
        adapter = RecyclerAdapter(movieList)
        mainRecView.adapter = adapter
        setRecyclerViewScrollListener()
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener)
    }

    override fun onStart() {
        super.onStart()
        /*
        if (movieList.size == 0) {
            requestMovie()
        }
        */
    }
    /*
    override fun receivedNewPhoto(newMovie: Movies) {
        runOnUiThread {
            movieList.add(newMovie)
            adapter.notifyItemInserted(movieList.size)
        }
    }
*/
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
