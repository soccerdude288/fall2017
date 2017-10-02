package com.example.taylor.cs3270a5;


import java.math.BigDecimal;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.ShareCompat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;


/**
 * A simple {@link Fragment} subclass.
 */
public class ChangeResults extends Fragment {

    BigDecimal changeToMake;
    //if no setting, default to $50
    BigDecimal MAX_AMOUNT = new BigDecimal(50.00);
    View root;
    int timeRemaining;
    BigDecimal changeTotalSoFar;

    public ChangeResults() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        root = inflater.inflate(R.layout.fragment_change_results, container, false);
        resetTime();
        if(changeToMake == null){
            generateAmount();
        }
        //setmax using get setting from main activity
        return root;
    }

    //Getters and Setters
    public void setChangeToMake(BigDecimal bd){
        changeToMake = bd;
    }
    public BigDecimal getChangeToMake(){
        return changeToMake;
    }
    public void setMax(BigDecimal max){
        MAX_AMOUNT = max;
    }
    public BigDecimal getMax(){
        return MAX_AMOUNT;
    }
    public void setTimeRemaining(int t){
        timeRemaining = t;
    }
    public int getTimeRemaining(){
        return timeRemaining;
    }
    public void setChangeTotalSoFar(BigDecimal bd){
        changeTotalSoFar = bd;
    }

    public BigDecimal getChangeTotalSoFar(){
        if(changeTotalSoFar != null)
            return changeTotalSoFar;
        else
            return new BigDecimal("0.00");
    }

    //Display Setters
    public void setChangeToMakeDisplay(BigDecimal value){
        TextView tv = (TextView) root.findViewById(R.id.changeToMakeValue);
        tv.setText("$".concat(value.toString()));
    }
    public void setChangeTotalSoFarDisplay(BigDecimal value){
        TextView tv = (TextView) root.findViewById(R.id.changeTotalSoFarValue);
        tv.setText("$".concat(getChangeTotalSoFar().toString()));
    }
    public void setTimeDisplay(int t){
        TextView tv = (TextView) root.findViewById(R.id.timeRemainingValue);
        tv.setText(Integer.toString(t));
    }

    //Generates the random amount to count to and sets global variable
    public void generateAmount(){
        Log.d("testing", "in generateAmount");
        BigDecimal zero = new BigDecimal("0.0");
        BigDecimal value = zero.add(new BigDecimal(Math.random()).multiply(MAX_AMOUNT.subtract(zero)));
        setChangeToMake(value.setScale(2,BigDecimal.ROUND_HALF_UP));
        setChangeToMakeDisplay(getChangeToMake());
    }

    public void resetTime(){
        Log.d("testing", "in resetTime");
        setTimeRemaining(30);
        setTimeDisplay(getTimeRemaining());
    }

    @Override
    public void onPause() {
        Log.d("testing", "in onPause changeresult");
        super.onPause();
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor ed = sp.edit();
        ed.putString("changeToMake", getChangeToMake().toString());
        ed.putString("changeSoFar", getChangeTotalSoFar().toString());
        ed.putInt("time", getTimeRemaining());
        ed.apply();
    }

    @Override
    public void onResume() {
        Log.d("testing", "in onResume changeresult");
        super.onResume();
        MainActivity ma = (MainActivity) getActivity();
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        BigDecimal value = new BigDecimal(sp.getString("changeToMake", "0.00"));
        if(value.toString() != "0.00")
            setChangeToMake(value);
        setTimeRemaining(sp.getInt("time", 30));
        if(ma.getInGame()) {
            setChangeTotalSoFar(new BigDecimal(sp.getString("changeSoFar", "0.00")));
            setChangeTotalSoFarDisplay(getChangeTotalSoFar());
            ma.startTimer(getTimeRemaining());
        }
        setChangeToMakeDisplay(getChangeToMake());
    }
}
