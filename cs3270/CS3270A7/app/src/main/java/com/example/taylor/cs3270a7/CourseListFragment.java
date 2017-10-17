package com.example.taylor.cs3270a7;


import android.database.Cursor;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.app.ListFragment;
import android.support.v4.widget.CursorAdapter;
import android.support.v4.widget.SimpleCursorAdapter;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseListFragment extends ListFragment {


    public CourseListFragment() {
        // Required empty public constructor
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
}
