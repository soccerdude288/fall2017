package com.example.taylor.cs3270a5;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.ShareCompat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.math.BigDecimal;


/**
 * A simple {@link Fragment} subclass.
 */
public class ChangeActions extends Fragment {

    Button startOver;
    Button newAmount;
    View root;
    int correctChangeCount;


    public ChangeActions() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        root = inflater.inflate(R.layout.fragment_change_actions, container, false);
        startOver = (Button) root.findViewById(R.id.btnStartOver);
        newAmount = (Button) root.findViewById(R.id.btnNewAmount);

        startOver.setOnClickListener(startOverPress);
        newAmount.setOnClickListener(newAmountPress);
        return root;
    }


    public void setCorrectChangeCount(int i){
        correctChangeCount = i;
    }
    public int getCorrectChangeCount(){
        return correctChangeCount;
    }


    public void setCorrectChangeDisplay(int i){
        TextView tv = (TextView) root.findViewById(R.id.correctCountValue);
        tv.setText(Integer.toString(i));
    }

    View.OnClickListener startOverPress = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in startOverPress");
            MainActivity ma = (MainActivity) getActivity();
            ma.resetGame();
            //reset timer
            //reset change so far
        }
    };

    View.OnClickListener newAmountPress = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in newAmountPress");
            MainActivity ma = (MainActivity) getActivity();
            ma.resetGame();
            ma.resetAmount();
            //reset timer
            //reset change so far
            //new value
        }
    };

    @Override
    public void onPause() {
        Log.d("testing", "in onPause changeActions");
        super.onPause();
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        SharedPreferences.Editor ed = sp.edit();
        ed.putInt("gamesWon", getCorrectChangeCount());
        ed.apply();
    }

    @Override
    public void onResume() {
        Log.d("testing", "in onPause changeActions");
        super.onResume();
        SharedPreferences sp = getActivity().getPreferences(Context.MODE_PRIVATE);
        int games = sp.getInt("gamesWon", 0);
        setCorrectChangeCount(games);
        setCorrectChangeDisplay(getCorrectChangeCount());
    }

}
