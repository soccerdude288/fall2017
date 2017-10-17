package com.example.taylor.cs3270a7;


import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseEditFragment extends Fragment {

    private View root;
    private EditText editID, editName, editCourse, editStart, editEnd;
    private FloatingActionButton saveBtn;
    private long curID;

    public void setCurID(long val){
        curID = val;
    }

    public long getCurID(){
        return curID;
    }


    public CourseEditFragment() {
        // Required empty public constructor
        curID = -1;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("testing", "in onCreate courseeditfrag");
        // Inflate the layout for this fragment
        root = inflater.inflate(R.layout.fragment_course_edit, container, false);
        editID = (EditText) root.findViewById(R.id.i_id);
        editName = (EditText) root.findViewById(R.id.i_name);
        editCourse = (EditText) root.findViewById(R.id.i_course);
        editStart = (EditText) root.findViewById(R.id.i_start);
        editEnd = (EditText) root.findViewById(R.id.i_end);
        saveBtn = (FloatingActionButton) root.findViewById(R.id.fab_Save);
        saveBtn.setOnClickListener(insert);


        return root;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        if(getCurID() != -1){
            populateClass(getCurID());
        }
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

        editID.setText(idV);
        editName.setText(name);
        editCourse.setText(course);
        editStart.setText(start);
        editEnd.setText(end);
    }

    View.OnClickListener insert = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in courseedit before insert");
            DatabaseHelper dbHelp = new DatabaseHelper(getActivity(), "Courses", null, 1);
            if(getCurID() != -1){
                long rowID = dbHelp.updateClass(
                        getCurID(),
                        editID.getText().toString(),
                        editName.getText().toString(),
                        editCourse.getText().toString(),
                        editStart.getText().toString(),
                        editEnd.getText().toString()
                );
            }
            else {
                long rowID = dbHelp.insertClass(
                        editID.getText().toString(),
                        editName.getText().toString(),
                        editCourse.getText().toString(),
                        editStart.getText().toString(),
                        editEnd.getText().toString()
                );
            }
            Log.d("testing", "in courseedit after insert");
            MainActivity ma = (MainActivity) getActivity();
            ma.goToList();
        }

    };

}
