package com.taylorearl.cs3270a3;


import android.os.Bundle;
import android.support.annotation.BoolRes;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;


/**
 * A simple {@link Fragment} subclass.
 */
public class bottom extends Fragment {



    private int computerWins;
    private int userWins;
    private int tieCount;
    private int totalPlayedGames;
    Button reset;


    public bottom() {
        // Required empty public constructor
    }

    private void reset(Boolean test){
        computerWins=0;
        userWins=0;
        tieCount=0;
        totalPlayedGames=0;
        update();

    }

    private void reset(){
        computerWins=0;
        userWins=0;
        tieCount=0;
        totalPlayedGames=0;
        update();
        Toast toast = Toast.makeText(getActivity(), "Game Reset", Toast.LENGTH_LONG);
        toast.show();
    }

    private void update(){
        TextView cWin = (TextView)getView().findViewById(R.id.phoneWinCount);
        TextView uWin = (TextView)getView().findViewById(R.id.myWinCount);
        TextView ties = (TextView)getView().findViewById(R.id.tieGame);
        TextView gPlayed = (TextView)getView().findViewById(R.id.gamesPlayed);

        cWin.setText(Integer.toString(computerWins));
        uWin.setText(Integer.toString(userWins));
        ties.setText(Integer.toString(tieCount));
        gPlayed.setText(Integer.toString(totalPlayedGames));
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_bottom, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();
        Boolean t = true;
        reset(t);
        reset = (Button)getView().findViewById(R.id.btnReset);
        reset.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                reset();
            }
        });
        reset.setBackgroundResource(android.R.drawable.btn_default);
    }

    public void gamePlayed(){
        totalPlayedGames ++;
        update();
    }

    public void computerWin(){
        computerWins ++;
        update();
    }

    public void playerWin(){
        userWins ++;
        update();
    }

    public void gameTie(){
        tieCount ++;
        update();
    }
}
