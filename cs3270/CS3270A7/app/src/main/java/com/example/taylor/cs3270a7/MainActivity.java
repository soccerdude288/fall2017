package com.example.taylor.cs3270a7;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.d("testing", "in onCreate main");
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new CourseListFragment(), "TO")
                .commit();

    }


    //sets the list fragment
    public void backToList(){

    }
}
