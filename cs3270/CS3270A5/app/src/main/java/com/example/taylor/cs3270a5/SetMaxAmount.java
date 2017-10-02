package com.example.taylor.cs3270a5;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.math.BigDecimal;


/**
 * A simple {@link Fragment} subclass.
 */
public class SetMaxAmount extends Fragment {


    public SetMaxAmount() {
        // Required empty public constructor
    }


    View view;
    Button save;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = (View) inflater.inflate(R.layout.fragment_set_max_amount, container, false);
        save = (Button) view.findViewById(R.id.saveButton);
        save.setOnClickListener(buttonPressr);
        MainActivity ma = (MainActivity) getActivity();
        String value = ma.getMaxAmount();
        EditText text1 = (EditText)view.findViewById(R.id.maxAmount);
        text1.setText(value);
        return view;
    }

    View.OnClickListener buttonPressr = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in buttonPress setMaxAmount");
            MainActivity ma = (MainActivity) getActivity();
            EditText text1 = view.findViewById(R.id.maxAmount);
            String maxValue = text1.getText().toString();
            int maxAmount = Integer.parseInt(maxValue);
            ma.setMaxAmount(maxAmount);
            Toast toast = Toast.makeText(ma,"Set Maximum", Toast.LENGTH_SHORT);
            toast.show();
            getFragmentManager().popBackStack();
        }
    };


}
