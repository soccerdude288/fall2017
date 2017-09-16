package com.taylorearl.cs3270a3;


import android.content.res.ColorStateList;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.util.Random;


/**
 * A simple {@link Fragment} subclass.
 */
public class top extends Fragment {

    public enum Opt{
        ROCK, PAPER, SCISSORS
    }

    public enum Result{
        WIN, LOSE, TIE
    }

    Button rock;
    Button paper;
    Button scissors;
    Opt playerChoice;
    Opt computerChoice;




    public top() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_top, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();

        rock = (Button)getView().findViewById(R.id.btnRock);
        paper = (Button)getView().findViewById(R.id.btnPaper);
        scissors = (Button)getView().findViewById(R.id.btnScissors);

        rock.setBackgroundResource(android.R.drawable.btn_default);
        paper.setBackgroundResource(android.R.drawable.btn_default);
        scissors.setBackgroundResource(android.R.drawable.btn_default);

        rock.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.ROCK;
                buttonColor(rock);
                generateChoice();
                setPhonePick();
                generateResult(playerChoice, computerChoice);
            }
        });

        paper.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.PAPER;
                buttonColor(paper);
                generateChoice();
                setPhonePick();
                generateResult(playerChoice, computerChoice);
            }
        });

        scissors.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.SCISSORS;
                buttonColor(scissors);
                generateChoice();
                setPhonePick();
                generateResult(playerChoice, computerChoice);
            }
        });

    }

    private void setPhonePick(){
        TextView pick = (TextView)getView().findViewById(R.id.phonePick);
        pick.setText(computerChoice.name());
    }

    private void setResult(Result results){
        TextView result = (TextView)getView().findViewById(R.id.result);
        result.setText(results.name());
    }

    private void buttonColor(Button btn){
        rock.setBackgroundResource(android.R.drawable.btn_default);
        paper.setBackgroundResource(android.R.drawable.btn_default);
        scissors.setBackgroundResource(android.R.drawable.btn_default);

        btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
    }

    private void generateChoice(){
        final Random rand = new Random();
        int compChoice = rand.nextInt(3) + 1; // uniformly distributed int from 1 to 6

        if(compChoice == 1){
            computerChoice = Opt.ROCK;
        }
        else if(compChoice == 2){
            computerChoice = Opt.PAPER;
        }
        else{
            computerChoice = Opt.SCISSORS;
        }
    }

    private void generateResult(Opt player, Opt computer){
        MainActivity ma = (MainActivity) getActivity();
        if(computer == Opt.PAPER){
            if(player == Opt.PAPER){
                //TIE
                ma.tieGame();
                setResult(Result.TIE);
            }
            else if(player == Opt.ROCK){
                //Computer Win
                //Player Lose
                ma.computerWin();
                setResult(Result.LOSE);
            }
            else{
                //Computer Lose
                //Player Win
                ma.userWin();
                setResult(Result.WIN);
            }
        }
        else if(computer == Opt.ROCK){
            if(player == Opt.PAPER){
                //Computer Lose
                //Player Win
                ma.userWin();
                setResult(Result.WIN);
            }
            else if(player == Opt.ROCK){
                //Tie
                ma.tieGame();
                setResult(Result.TIE);
            }
            else{
                //Computer Win
                //Player Lose
                ma.computerWin();
                setResult(Result.LOSE);
            }
        }
        else{
            if(player == Opt.PAPER){
                //Computer Win
                //Player Lose
                ma.computerWin();
                setResult(Result.LOSE);
            }
            else if(player == Opt.ROCK){
                //Player Win
                //Computer Lose
                ma.userWin();
                setResult(Result.WIN);

            }
            else{
                //Tie Game
                ma.tieGame();
                setResult(Result.TIE);
            }
        }

    }
}
