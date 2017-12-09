package com.taylorearl.movietracker


import android.os.Bundle
import android.support.v4.app.Fragment
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import kotlinx.android.synthetic.main.fragment_my_stuff.*


/**
 * A simple [Fragment] subclass.
 */
class MyStuffFrag : Fragment() {

    private lateinit var linearLayoutManager: LinearLayoutManager
    private lateinit var adapter: RecyclerAdapter
    private val lastVisibleItemPosition: Int
        get() = linearLayoutManager.findLastVisibleItemPosition()
    private var movieList: ArrayList<Movies> = ArrayList()

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        // Inflate the layout for this fragment
        return inflater!!.inflate(R.layout.fragment_my_stuff, container, false)
    }

    override fun onResume() {
        super.onResume()
        val ma = activity as MainActivity
        ma.supportActionBar!!.setSubtitle("My Movies")
        val dbHelp = DatabaseHelper(ma)
        //loadingPanel.setVisibility(View.VISIBLE)
        val movieList = dbHelp.allMovies;
        //loadingPanel.setVisibility(View.GONE)

        linearLayoutManager = LinearLayoutManager(ma)
        myMainRecView.layoutManager = linearLayoutManager
        adapter = RecyclerAdapter(movieList as ArrayList<Movies>, this)
        myMainRecView.adapter = adapter
        setRecyclerViewScrollListener()

    }

    private fun setRecyclerViewScrollListener() {
        myMainRecView.addOnScrollListener(object : RecyclerView.OnScrollListener() {
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

}// Required empty public constructor
