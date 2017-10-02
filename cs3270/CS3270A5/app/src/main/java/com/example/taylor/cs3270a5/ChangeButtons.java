package com.example.taylor.cs3270a5;


import android.os.Bundle;
import android.support.v4.app.Fragment;
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
public class ChangeButtons extends Fragment {

    View view;
    Button d50;
    Button d20;
    Button d10;
    Button d5;
    Button d1;
    Button c50;
    Button c25;
    Button c10;
    Button c5;
    Button c1;


    public ChangeButtons() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = (View) inflater.inflate(R.layout.fragment_change_buttons, container, false);
        d50 = (Button) view.findViewById(R.id.button50);
        d20 = (Button) view.findViewById(R.id.button20);
        d10 = (Button) view.findViewById(R.id.button10);
        d5 = (Button) view.findViewById(R.id.button5);
        d1 = (Button) view.findViewById(R.id.button1);
        c50 = (Button) view.findViewById(R.id.button50c);
        c25 = (Button) view.findViewById(R.id.button25c);
        c10 = (Button) view.findViewById(R.id.button10c);
        c5 = (Button) view.findViewById(R.id.button5c);
        c1 = (Button) view.findViewById(R.id.button1c);

        d50.setOnClickListener(buttonPress);
        d20.setOnClickListener(buttonPress);
        d10.setOnClickListener(buttonPress);
        d5.setOnClickListener(buttonPress);
        d1.setOnClickListener(buttonPress);
        c50.setOnClickListener(buttonPress);
        c25.setOnClickListener(buttonPress);
        c10.setOnClickListener(buttonPress);
        c5.setOnClickListener(buttonPress);
        c1.setOnClickListener(buttonPress);

        return view;
    }

    View.OnClickListener buttonPress = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.d("testing", "in buttonPress");
            MainActivity ma = (MainActivity) getActivity();
            if(!ma.getInGame()){
                ma.startGame();
            }

            //txvMessage = (TextView) view.findViewById(R.id.txvMessage);
            //txvMessage.setText(btnDoSomething.getText().toString());
            Button clickedButton = (Button) v;
            String buttonCaption = clickedButton.getText().toString();
            buttonCaption = buttonCaption.replace("$","");
            BigDecimal value = new BigDecimal(buttonCaption);
            ma.addToTotal(value);
            //convert txt value to bigdecimal
            //send the value up to the main activity
            //ma.addToTotal();
        }
    };

}
