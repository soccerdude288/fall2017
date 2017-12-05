package com.taylorearl.movietracker

import android.content.Intent
import android.os.Bundle
import android.support.design.widget.BottomNavigationView
import android.support.v7.app.AppCompatActivity
import android.support.v7.widget.Toolbar
import android.util.Log
import android.view.Menu
import android.view.View
import kotlinx.android.synthetic.main.activity_main.*
import android.view.MenuInflater
import android.os.AsyncTask.execute
import android.view.MenuItem


class MainActivity : AppCompatActivity() {


    private val mOnNavigationItemSelectedListener = BottomNavigationView.OnNavigationItemSelectedListener { item ->
        when (item.itemId) {
            R.id.navigation_home -> {
                Log.d("testing", "Start nav-home")
                supportFragmentManager
                        .beginTransaction()
                        .replace(R.id.mainView, HomeFrag(), "homeFragment")
                        .addToBackStack(null)
                        .commit()
                Log.d("testing", "End nav-home")
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_stuff -> {
                Log.d("testing", "Start nav-stuff")
                supportFragmentManager
                        .beginTransaction()
                        .replace(R.id.mainView, MyStuffFrag(), "searchFragment")
                        .addToBackStack(null)
                        .commit()
                Log.d("testing", "End nav-stuff")
                return@OnNavigationItemSelectedListener true
            }
            R.id.navigation_search -> {
                Log.d("testing", "Start nav-search")
                supportFragmentManager
                        .beginTransaction()
                        .replace(R.id.mainView, SearchFrag(), "searchFragment")
                        .addToBackStack(null)
                        .commit()
                Log.d("testing", "End nav-search")
                return@OnNavigationItemSelectedListener true
            }
        }
        false
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        Log.d("testing", "Start activity on create")
        setContentView(R.layout.activity_main)
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener)
        Log.d("testing", "set home fragment")
        if(false){
            val dbhelp = DatabaseHelper(this);
            dbhelp.dropMovies()
        }
        supportFragmentManager
                .beginTransaction()
                .replace(R.id.mainView, HomeFrag(), "homeFragment")
                .addToBackStack(null)
                .commit()
    }

    fun showMovieDetails(md:MovieDetailResponse){
        Log.d("testing", "Start ma movie details")
        val intent = Intent(this, MovieDetailActivity::class.java)
        intent.putExtra("MOVIE", md)
        startActivity(intent)
        Log.d("testing", "End ma movie details")
    }

    override fun onSupportNavigateUp(): Boolean {
        Log.d("testing", "Action Bar back pressed")
        this.onBackPressed()
        return true
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        val inflater = menuInflater
        inflater.inflate(R.menu.menu, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.getItemId()) {
            R.id.menu_about -> {
                val intent = Intent(this, AboutActivity::class.java)
                startActivity(intent)
                return true
            }
            else ->
                // If we got here, the user's action was not recognized.
                // Invoke the superclass to handle it.
                return super.onOptionsItemSelected(item)
        }
    }

}
