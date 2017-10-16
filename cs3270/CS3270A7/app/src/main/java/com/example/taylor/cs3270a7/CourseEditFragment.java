package com.example.taylor.cs3270a7;


import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;


/**
 * A simple {@link Fragment} subclass.
 */
public class CourseEditFragment extends Fragment {

    private View root;
    private EditText editID, editName, editCourse, editStart, editEnd;
    private FloatingActionButton saveBtn;

    public CourseEditFragment() {
        // Required empty public constructor
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

    View.OnClickListener insert = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in courseedit before insert");
            DatabaseHelper dbHelp = new DatabaseHelper(getActivity(), "Courses", null, 1);
            long rowID = dbHelp.insertClass(
                    editID.getText().toString(),
                    editName.getText().toString(),
                    editCourse.getText().toString(),
                    editStart.getText().toString(),
                    editEnd.getText().toString()
            );
            Log.d("testing", "in courseedit after insert");
            MainActivity ma = (MainActivity) getActivity();
            ma.backToList();
        }

    };

}
