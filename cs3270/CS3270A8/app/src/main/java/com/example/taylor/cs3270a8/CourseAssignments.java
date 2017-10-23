package com.example.taylor.cs3270a8;


import android.database.Cursor;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;

import javax.net.ssl.HttpsURLConnection;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseAssignments extends Fragment {

    ListView assignmentList;
    ArrayAdapter<String> adapter;
    ArrayList<String> list;
    View view;
    DatabaseHelper dbHelp;
    String courseID;
    public CourseAssignments() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        MainActivity ma = (MainActivity) getActivity();
        view = inflater.inflate(R.layout.fragment_course_assignments, container, false);
        list = new ArrayList<>();
        assignmentList = (ListView) view.findViewById(R.id.assignmentList);
        adapter = new ArrayAdapter<String>(ma, android.R.layout.simple_list_item_1,list);
        assignmentList.setAdapter(adapter);
        dbHelp = new DatabaseHelper(ma, "Courses", null, 1);
        courseID = getCourseID();
        new CourseAssignments.getCanvasAssignments().execute("");
        return view;
    }

    private String getCourseID(){
        MainActivity ma = (MainActivity) getActivity();
        Cursor cursor;
        cursor = dbHelp.getClassID(ma.getIdHelper());
        cursor.moveToFirst();
        return cursor.getString(cursor.getColumnIndex("id"));
    }


    public class getCanvasAssignments extends AsyncTask<String, Integer, String> {
        String AUTH_TOKEN = Authentication.KEY;
        String rawJson = "";

        @Override
        protected String doInBackground(String... strings) {
            Log.d("taylorTest", "In AsyncTask getCanvasCourses");
            try{
                URL url = new URL("https://weber.instructure.com/api/v1/courses/"+ courseID + "/assignments");
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
            try{
                CanvasObject.Assignment[] assignments = jsonParse(s);
                for(CanvasObject.Assignment assignment : assignments){
                    list.add(assignment.name);
                }
                adapter.notifyDataSetChanged();
            } catch (Exception e){
                Log.d("taylorTest", e.getMessage());
            }
        }

        private CanvasObject.Assignment[] jsonParse(String rawJson){
            GsonBuilder gsonb = new GsonBuilder();
            Gson gson = gsonb.create();

            CanvasObject.Assignment[] assignments = null;

            try{
                assignments = gson.fromJson(rawJson, CanvasObject.Assignment[].class);
                Log.d("taylorTest", "number of assignments returned is: " + assignments.length);
                Log.d("taylorTest", "First Course returned is: " + assignments[0].name);
            } catch(Exception e){
                Log.d("taylorTest", e.getMessage());
            }
            return assignments;
        }
    }

}
