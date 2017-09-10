package com.taylorearl.cs3270a3;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import java.util.Random;


/**
 * A simple {@link Fragment} subclass.
 */
public class top extends Fragment {

    public enum Opt{
        ROCK, PAPER, SCISSORS
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

        rock.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.ROCK;
                generateChoice();
                generateResult(playerChoice, computerChoice);
            }
        });

        paper.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.PAPER;
                generateChoice();
                generateResult(playerChoice, computerChoice);
            }
        });

        scissors.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                playerChoice = Opt.SCISSORS;
                generateChoice();
                generateResult(playerChoice, computerChoice);
            }
        });

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

    private void generateResult(Opt computer, Opt player){
        if(computer == Opt.PAPER){
            if(player == Opt.PAPER){
                //TIE
            }
            else if(player == Opt.ROCK){
                //Computer Win
                //Player Lose
            }
            else{
                //Computer Lose
                //Player Win
            }
        }
        else if(computer == Opt.ROCK){
            if(player == Opt.PAPER){
                //Computer Lose
                //Player Win
            }
            else if(player == Opt.ROCK){
                //Tie
            }
            else{
                //Computer Win
                //Player Lose
            }
        }
        else{
            if(player == Opt.PAPER){

            }
            else if(player == Opt.ROCK){

            }
            else{

            }
        }

    }
}
