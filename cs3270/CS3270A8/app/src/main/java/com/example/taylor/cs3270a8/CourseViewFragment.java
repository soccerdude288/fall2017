package com.example.taylor.cs3270a8;


import android.content.Context;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseViewFragment extends Fragment {


    public CourseViewFragment() {
        // Required empty public constructor
    }

    View root;
    TextView l_id, l_name, l_course, l_start, l_end;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("testing", "in onCreate courseviewfrag");
        // Inflate the layout for this fragment
        root = inflater.inflate(R.layout.fragment_course_view, container, false);
        l_id = (TextView) root.findViewById(R.id.v_viewId);
        l_name = (TextView) root.findViewById(R.id.v_viewName);
        l_course = (TextView) root.findViewById(R.id.v_viewCourse);
        l_start = (TextView) root.findViewById(R.id.v_viewStart);
        l_end = (TextView) root.findViewById(R.id.v_viewEnd);
        setHasOptionsMenu(true);
        return root;
    }


    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        super.onCreateOptionsMenu(menu, inflater);
        inflater.inflate(R.menu.menu, menu);
    }

    public void populateClass(long id){
        DatabaseHelper dbHelp = new DatabaseHelper(getActivity(), "Courses", null, 1);
        Cursor cursor = dbHelp.getOneClass(id);
        cursor.moveToFirst();

        String name = cursor.getString(cursor.getColumnIndex("name"));
        String course = cursor.getString(cursor.getColumnIndex("course"));
        String idV = cursor.getString(cursor.getColumnIndex("id"));
        String start = cursor.getString(cursor.getColumnIndex("start"));
        String end = cursor.getString(cursor.getColumnIndex("end"));

        l_id.setText(idV);
        l_name.setText(name);
        l_course.setText(course);
        l_start.setText(start);
        l_end.setText(end);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        MainActivity ma = (MainActivity) getActivity();
        long id = ma.getIdHelper();
        if(id == 0){
            SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
            id = sp.getLong("curID", 0);
        }
        populateClass(id);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_edit:
                MainActivity ma = (MainActivity) getActivity();
                ma.goToEdit(ma.getIdHelper());
                //Snackbar.make(root, "Replace with your own action", Snackbar.LENGTH_LONG).setAction("Action", null).show();
                return true;

            case R.id.action_delete:
                DeleteConfirmDialogFragment dialog = new DeleteConfirmDialogFragment();
                dialog.setCancelable(false);
                dialog.show(getActivity().getSupportFragmentManager(), "Delete Confirm");
                //Snackbar.make(root, "Replace with your own action", Snackbar.LENGTH_LONG).setAction("Action", null).show();
                return true;

            default:
                // If we got here, the user's action was not recognized.
                // Invoke the superclass to handle it.
                return super.onOptionsItemSelected(item);

        }
    }

}
