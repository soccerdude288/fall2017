package com.taylorearl.cs3270midterm_earl;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.math.BigDecimal;


/**
 * A simple {@link Fragment} subclass.
 */
public class ResultsFragment extends Fragment {


    public ResultsFragment() {
        // Required empty public constructor
    }

    float bmi;
    float bfp;
    View root;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("testing", "in onCreate Results");
        // Inflate the layout for this fragment
        root = inflater.inflate(R.layout.fragment_results, container, false);


        return root;
    }

    public float getBMI(){
        return bmi;
    }
    public void setBMI(float value){
        bmi = value;
        setBMIDisplay(bmi);
    }
    public void setBMIDisplay(float value){
        TextView tv = (TextView) root.findViewById(R.id.r_bmi);
        tv.setText(Float.toString(round(value, 2)));
    }

    public float getBFP(){
        return bfp;
    }
    public void setBFP(float value){
        bfp = value;
        setBFPDisplay(bfp);
    }
    public void setBFPDisplay(float value){
        TextView tv = (TextView) root.findViewById(R.id.r_bfp);
        tv.setText(Float.toString(round(value, 2)));
    }


    @Override
    public void onPause() {
        Log.d("testing", "in onPause Results");
        super.onPause();
        saveItems();
    }

    @Override
    public void onResume() {
        Log.d("testing", "in onResume Results");
        super.onResume();
        restoreState();
    }


    private void saveItems(){
        Log.d("testing", "in saveItems Results");
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor spEditor = sp.edit();
        spEditor.putFloat("bmi", getBMI());
        spEditor.putFloat("bfp", getBFP());
        spEditor.apply();
    }

    private void restoreState(){
        Log.d("testing", "in restoreState Results");
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        setBMI(sp.getFloat("bmi", 0));
        setBFP(sp.getFloat("bfp", 0));
    }


    //quick rounding function taken from stack overflow
    public static float round(float d, int decimalPlace) {
        BigDecimal bd = new BigDecimal(Float.toString(d));
        bd = bd.setScale(decimalPlace, BigDecimal.ROUND_HALF_UP);
        return bd.floatValue();
    }
}
