package com.taylorearl.movietracker

import android.os.Bundle
import android.support.design.widget.BottomNavigationView
import android.support.v7.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {


    private val mOnNavigationItemSelectedListener = BottomNavigationView.OnNavigationItemSelectedListener { item ->
        when (item.itemId) {
            R.id.navigation_home -> {
                //message.setText(R.string.title_home)
                supportFragmentManager
                        .beginTransaction()
                        .replace(R.id.mainView, HomeFrag(), "homeFragment")
                        .addToBackStack(null)
                        .commit()
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_stuff -> {
                //message.setText(R.string.title_myStuff)
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_search -> {
                supportFragmentManager
                        .beginTransaction()
                        .replace(R.id.mainView, SearchFrag(), "searchFragment")
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
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener)
        supportFragmentManager
                .beginTransaction()
                .replace(R.id.mainView, HomeFrag(), "homeFragment")
                .addToBackStack(null)
                .commit()
    }

    fun showMovieDetails(md:MovieDetailResponse){
        var movieDetails = MovieDetails();
        movieDetails.setDetails(md);
        supportFragmentManager
                .beginTransaction()
                .replace(R.id.mainView, movieDetails, "movieDetails")
                .addToBackStack(null)
                .commit()
    }

}
