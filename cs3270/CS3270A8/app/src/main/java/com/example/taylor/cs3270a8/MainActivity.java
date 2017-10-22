package com.example.taylor.cs3270a8;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.google.gson.Gson;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;

public class MainActivity extends AppCompatActivity {


    //private DatabaseHelper dbHelp;
    private long id;

    public long getIdHelper(){
        return id;
    }

    enum appStateVal {LIST, VIEW, EDIT};
    public appStateVal appState;

    public appStateVal getAppState(){
        return appState;
    }

    public void setAppState(appStateVal av){
        this.appState = av;
    }

    public class getCanvasCourses extends AsyncTask<String, Integer, String>{
        String AUTH_TOKEN = Authentication.KEY;
        String rawJson = "";

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In AsyncTask getCanvasCourses");
            try{
                URL url = new URL("https://weber.instructure.com/api/v1/courses");
                HttpsURLConnection conn = (HttpsURLConnection) url.openConnection();
                conn.setRequestMethod("GET");
                conn.setRequestProperty("Authorization", "Bearer " + AUTH_TOKEN);
                conn.connect();
                int status = conn.getResponseCode();
                switch (status){
                    case 200:
                    case 201:
                        BufferedReader br =
                                new BufferedReader(new InputStreamReader(conn.getInputStream()));
                        rawJson = br.readLine();
                }
            }
            catch (MalformedURLException e){
                Log.d("taylorTest",e.getMessage());
            }
            catch (IOException e){
                Log.d("taylorTest",e.getMessage());
            }

            return null;
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.d("testing", "in onCreate main");
        setContentView(R.layout.activity_main);

        Gson gson = new Gson();

        //used in an attempt to make sure clicking the back button properly set state,
        //but this was also getting called when adding new fragments, essentially
        //breaking the app
        /*
        getSupportFragmentManager().addOnBackStackChangedListener(
                new FragmentManager.OnBackStackChangedListener() {
                    public void onBackStackChanged() {
                        if(getAppState() == appStateVal.EDIT){
                            setAppState(appStateVal.VIEW);
                        }
                        else if(getAppState() == appStateVal.VIEW){
                            setAppState(appStateVal.LIST);
                        }
                    }
                });
        */
    }

    public void goToEdit(){
        setAppState(appStateVal.EDIT);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new CourseEditFragment(), "TO")
                .addToBackStack(null)
                .commit();
    }

    public void goToEdit(long id){
        setAppState(appStateVal.EDIT);
        CourseEditFragment ce = new CourseEditFragment();
        ce.setCurID(id);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, ce, "TO")
                .addToBackStack(null)
                .commit();
    }

    //sets the list fragment
    public void goToList(){
        setAppState(appStateVal.LIST);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new CourseListFragment(), "TO")
                .commit();
    }

    public void goToView(long id){
        setAppState(appStateVal.VIEW);
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

    @Override
    protected void onPause() {
        super.onPause();
        SharedPreferences sp = this.getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor ed = sp.edit();
        if(isChangingConfigurations()){
            ed.putString("state", getAppState().toString());
            ed.putLong("curID", getIdHelper());
        }
        else{
            ed.putString("state", "LIST");
            ed.putLong("curID", 0);
        }
        ed.apply();

    }

    @Override
    protected void onResume() {
        super.onResume();
        SharedPreferences sp = this.getPreferences(Context.MODE_PRIVATE);
        this.id = sp.getLong("curID", 0);
        setAppState(appStateVal.valueOf(sp.getString("state", "LIST")));
        if(getAppState().equals(appStateVal.LIST)){
            goToList();
        }
        else if(getAppState().equals(appStateVal.VIEW)){
            goToList();
            goToView(getIdHelper());
        }
        else{
            if(getIdHelper()==0){
                goToList();
                goToEdit();
            }
            else{
                goToList();
                goToView(getIdHelper());
                goToEdit(getIdHelper());
            }
        }
    }



}
