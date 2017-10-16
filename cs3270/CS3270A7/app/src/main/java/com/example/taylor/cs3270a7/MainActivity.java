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

    public void goToEdit(){
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new CourseEditFragment(), "TO")
                .commit();
    }

    //sets the list fragment
    public void backToList(){
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new CourseListFragment(), "TO")
                .commit();
    }

    public void populateClass(long id){
        CourseViewFragment cv = new CourseViewFragment();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, cv, "TO")
                .addToBackStack(null)
                .commit();
        this.id = id;
    }
    public void deleteRecord(){
        DatabaseHelper dbHelp = new DatabaseHelper(this, "Courses", null, 1);
        dbHelp.deleteOneClass(this.id);
    }

    //private DatabaseHelper dbHelp;
    private long id;

    public long getIdHelper(){
        return id;
    }
}
