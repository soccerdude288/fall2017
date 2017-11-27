package com.taylorearl.movietracker


import android.os.Bundle
import android.support.v4.app.Fragment
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import kotlinx.android.synthetic.main.fragment_home.*


/**
 * A simple [Fragment] subclass.
 */
class HomeFrag : Fragment() {

    private lateinit var linearLayoutManager: LinearLayoutManager
    private lateinit var adapter: RecyclerAdapter
    private val lastVisibleItemPosition: Int
        get() = linearLayoutManager.findLastVisibleItemPosition()
    private var movieList: ArrayList<Movies> = ArrayList()


    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        // Inflate the layout for this fragment
        return inflater!!.inflate(R.layout.fragment_home, container, false)
    }

    override fun onResume() {
        super.onResume()
        val api = TheMovieDBAPI()
        api.setPopularSearchParams()
        //loadingPanel.setVisibility(View.VISIBLE)
        val movieList = api.popularSearch().execute("")
        //loadingPanel.setVisibility(View.GONE)
        while(!api.hasResults){
            val a = 0;
        }
        linearLayoutManager = LinearLayoutManager(context)
        mainRecView.layoutManager = linearLayoutManager
        adapter = RecyclerAdapter(api.movieList as ArrayList<Movies>)
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
}// Required empty public constructor
