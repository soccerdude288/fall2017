package com.example.taylor.cs3270a8;


import android.database.Cursor;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.app.ListFragment;
import android.support.v4.widget.CursorAdapter;
import android.support.v4.widget.SimpleCursorAdapter;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseListFragment extends ListFragment {


    public CourseListFragment() {
        // Required empty public constructor
    }

    public class getCanvasCourses extends AsyncTask<String, Integer, String> {
        String AUTH_TOKEN = Authentication.KEY;
        String rawJson = "";

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In AsyncTask getCanvasCourses");
            try{
                URL url = new URL("https://weber.instructure.com/api/v1/courses?enrollment_state=active");
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
                        Log.d("taylorTest", "ras JSON String Length = " + rawJson.length());
                        Log.d("taylorTest", "ras JSON first 256 chars = " + rawJson.substring(0, 256));
                        Log.d("taylorTest", "ras JSON last 256 chars = " + rawJson.substring(rawJson.length() - 256, rawJson.length()));
                }
            }
            catch (MalformedURLException e){
                Log.d("taylorTest",e.getMessage());
            }
            catch (IOException e){
                Log.d("taylorTest",e.getMessage());
            }

            return rawJson;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            MainActivity ma = (MainActivity) getActivity();
            //courseAdapter.clear();
            DatabaseHelper dbHelp = new DatabaseHelper(ma, "Courses", null, 1);
            dbHelp.dropClasses();
            try{
                CanvasObject.Course[] courses = jsonParse(s);
                for(CanvasObject.Course course : courses){
                    dbHelp.insertClass(course.id, course.name, course.course_code, course.start_at, course.end_at);
                }
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            ma.goToList();
        }

        private CanvasObject.Course[] jsonParse(String rawJson){
            GsonBuilder gsonb = new GsonBuilder();
            Gson gson = gsonb.create();

            CanvasObject.Course[] courses = null;

            try{
                courses = gson.fromJson(rawJson, CanvasObject.Course[].class);
                Log.d("taylorTest", "number of courses returned is: " + courses.length);
                Log.d("taylorTest", "First Course returned is: " + courses[0].name);
            } catch(Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return courses;
        }
    }

    View view;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        Log.d("testing", "in onCreate courselistfragment");
        view =  inflater.inflate(R.layout.fragment_course_list, container, false);

        DatabaseHelper dbHelp = new DatabaseHelper(getActivity(), "Courses", null, 1);
        Cursor cursor = dbHelp.getAllClasses();
        String[] columns = new String[] {"name"};
        Log.d("testing", "after getAllClasses() courselistfragment");
        int[] views = new int[] {android.R.id.text1};
        SimpleCursorAdapter adapter = new SimpleCursorAdapter(getActivity(),
                android.R.layout.simple_list_item_1,
                cursor, columns, views,
                CursorAdapter.FLAG_REGISTER_CONTENT_OBSERVER);
        setListAdapter(adapter);
        Log.d("testing", "after setListAdapter() courselistfragment");
        setHasOptionsMenu(true);
        FloatingActionButton fab = (FloatingActionButton) view.findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MainActivity ma = (MainActivity) getActivity();
                ma.goToEdit();
                //Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG).setAction("Action", null).show();
            }
        });
        return view;
    }

    @Override
    public void onListItemClick(ListView l, View v, int position, long id) {
        super.onListItemClick(l, v, position, id);
        Log.d("testing", "in courselistfrag onlistitemclick");
        MainActivity ma = (MainActivity) getActivity();
        ma.goToView(id);
    }



    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        super.onCreateOptionsMenu(menu, inflater);
        inflater.inflate(R.menu.main_menu, menu);
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_import:
                new getCanvasCourses().execute("");
                //Snackbar.make(root, "Replace with your own action", Snackbar.LENGTH_LONG).setAction("Action", null).show();
                return true;
            default:
                // If we got here, the user's action was not recognized.
                // Invoke the superclass to handle it.
                return super.onOptionsItemSelected(item);

        }
    }

    @Override
    public void onResume() {
        super.onResume();
        getListView().setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> adapterView, View view, int i, long l) {
                MainActivity ma = (MainActivity) getActivity();
                ma.goToAssignments(l);
                return false;
            }
        });
    }
}
