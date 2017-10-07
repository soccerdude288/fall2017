package com.taylorearl.cs3270midterm_earl;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

import java.math.BigDecimal;


/**
 * A simple {@link Fragment} subclass.
 */
public class ActionFragment extends Fragment {


    public ActionFragment() {
        // Required empty public constructor
    }
    View view;
    Button calc;
    int lbs;
    int in;
    int age;
    boolean isFemale;
    RadioButton female;
    RadioButton male;

    public void setLBS(int value){
        lbs = value;
        setLbsDisplay();
    }

    public int getLBS(){
        return lbs;
    }

    public void setLbsDisplay(){
        EditText et = (EditText) view.findViewById(R.id.i_weight);
        et.setText(Integer.toString(getLBS()));
    }

    public void setIn(int value){
        in = value;
        setInDisplay();
    }

    public int getIn(){
        return in;
    }

    public void setInDisplay(){
        EditText et = (EditText) view.findViewById(R.id.i_height);
        et.setText(Integer.toString(getIn()));
    }

    public void setAge(int value){
        age = value;
        setAgeDisplay();
    }

    public int getAge(){
        return age;
    }

    public void setAgeDisplay(){
        EditText et = (EditText) view.findViewById(R.id.i_age);
        et.setText(Integer.toString(getAge()));
    }

    public void setIsFemale(boolean isFemale){
        this.isFemale = isFemale;
        setIsFemaleDisplay();
    }

    public boolean getIsFemale(){
        return isFemale;
    }

    public void setIsFemaleDisplay(){
        boolean isF = getIsFemale();

        if(isF == true){
            female.setChecked(true);
            male.setChecked(false);
        }
        else{
            female.setChecked(false);
            male.setChecked(true);
        }
    }



    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("testing", "in onCreate Action");
        // Inflate the layout for this fragment
        view = (View) inflater.inflate(R.layout.fragment_action, container, false);
        calc = (Button) view.findViewById(R.id.b_calc);
        female = (RadioButton) view.findViewById(R.id.r_Female);
        male = (RadioButton) view.findViewById(R.id.r_Male);
        calc.setOnClickListener(buttonPress);
        male.setOnClickListener(radioPress);
        female.setOnClickListener(radioPress);

        return view;
    }

    View.OnClickListener radioPress = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in radioPress Action");
            RadioButton clickedButton = (RadioButton) v;
            String buttonCaption = clickedButton.getText().toString();
            if(buttonCaption.equals("Male")){
                female.setChecked(false);
            }
            else{
                male.setChecked(false);
            }
        }
    };


    View.OnClickListener buttonPress = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in buttonPress Action");
            EditText ht = (EditText) view.findViewById(R.id.i_height);
            setIn(Integer.parseInt(ht.getText().toString()));

            EditText wt = (EditText) view.findViewById(R.id.i_weight);
            setLBS(Integer.parseInt(wt.getText().toString()));

            EditText ag = (EditText) view.findViewById(R.id.i_age);
            setAge(Integer.parseInt(ag.getText().toString()));

            RadioButton f = (RadioButton) view.findViewById(R.id.r_Female);
            if(f.isChecked() == true){
                setIsFemale(true);
            }
            else{
                setIsFemale(false);
            }

            MainActivity ma = (MainActivity) getActivity();
            ma.calculate(getLBS(), getIn(), getAge(), getIsFemale());
        }
    };


    @Override
    public void onResume() {
        Log.d("testing", "in onResume Action");
        super.onResume();
        restoreState();
    }

    @Override
    public void onPause() {
        Log.d("testing", "in onPause Action");
        super.onPause();
        EditText ht = (EditText) view.findViewById(R.id.i_height);
        setIn(Integer.parseInt(ht.getText().toString()));

        EditText wt = (EditText) view.findViewById(R.id.i_weight);
        setLBS(Integer.parseInt(wt.getText().toString()));

        EditText ag = (EditText) view.findViewById(R.id.i_age);
        setAge(Integer.parseInt(ag.getText().toString()));

        RadioButton f = (RadioButton) view.findViewById(R.id.r_Female);
        if(f.isChecked() == true){
            setIsFemale(true);
        }
        else{
            setIsFemale(false);
        }
        saveItems();
    }


    private void saveItems(){
        Log.d("testing", "in saveItems Action");
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor spEditor = sp.edit();
        spEditor.putInt("lbs", getLBS());
        spEditor.putInt("in", getIn());
        spEditor.putInt("age", getAge());
        spEditor.putBoolean("isFemale", getIsFemale());
        spEditor.apply();
    }

    private void restoreState(){
        Log.d("testing", "in restoreState Action");
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        setLBS(sp.getInt("lbs", 0));
        setIn(sp.getInt("in", 0));
        setAge(sp.getInt("age", 0));
        setIsFemale(sp.getBoolean("isFemale", true));
    }
}
