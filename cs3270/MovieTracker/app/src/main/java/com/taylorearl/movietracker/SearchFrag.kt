package com.taylorearl.movietracker


import android.os.Bundle
import android.support.v4.app.Fragment
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.util.Log
import android.view.KeyEvent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.fragment_search.*
import kotlinx.android.synthetic.main.fragment_search.view.*


/**
 * A simple [Fragment] subclass.
 */
class SearchFrag : Fragment() {
    private lateinit var linearLayoutManager: LinearLayoutManager
    private lateinit var adapter: RecyclerAdapter

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        // Inflate the layout for this fragment
        Log.d("taylorTest", "In oncreate search fragment")
        return inflater!!.inflate(R.layout.fragment_search, container, false)

    }

    override fun onStart() {
        super.onStart()
        //loadingPanel.setVisibility(View.GONE)
        Log.d("taylorTest", "In onStart search fragment")
        val ma = activity as MainActivity
        ma.supportActionBar!!.setSubtitle("Search")
        searchBox.setOnKeyListener(View.OnKeyListener{v, keyCode, event ->
            Log.d("taylorTest", "In key listener search fragment")
            if(keyCode == KeyEvent.KEYCODE_ENTER){
                Log.d("taylorTest", "In in enter key listener search fragment")
                val searchValue = searchBox.text.toString();
                val api = TheMovieDBAPI()
                api.setSearchParams(searchValue)
                //loadingPanel.setVisibility(View.VISIBLE)
                val movieList = api.movieSearch().execute("")
                //loadingPanel.setVisibility(View.GONE)
                linearLayoutManager = LinearLayoutManager(activity)
                resultsRecView.layoutManager = linearLayoutManager
                adapter = RecyclerAdapter(api.movieList as ArrayList<Movies>, this)
                resultsRecView.adapter = adapter
                setRecyclerViewScrollListener()
                return@OnKeyListener true
            }
            false
        })
    }

    private fun setRecyclerViewScrollListener() {
        resultsRecView.addOnScrollListener(object : RecyclerView.OnScrollListener() {
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
