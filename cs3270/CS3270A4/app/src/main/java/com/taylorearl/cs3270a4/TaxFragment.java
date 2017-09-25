package com.taylorearl.cs3270a4;


import android.content.Intent;
import java.math.BigDecimal;
import java.util.Locale;

import android.icu.text.NumberFormat;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.TextViewCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.SeekBar;
import android.widget.TextView;


/**
 * A simple {@link Fragment} subclass.
 */
public class TaxFragment extends Fragment {


    public TaxFragment() {
        // Required empty public constructor
    }

    SeekBar seekBar;
    View rootView;
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        rootView = (View) inflater.inflate(R.layout.fragment_tax, container, false);

        seekBar = (SeekBar)rootView.findViewById(R.id.seekBar);
        seekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                MainActivity ma = (MainActivity) getActivity();
                int progress = seekBar.getProgress();
                ma.setSeekValue(progress);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        return rootView;
    }

    @Override
    public void startActivity(Intent intent) {
        super.startActivity(intent);

    }

    public void updateDisplay(BigDecimal rate, BigDecimal amount){
        TextView taxRate = (TextView)getView().findViewById(R.id.taxRate);
        TextView taxAmount = (TextView)getView().findViewById(R.id.taxAmount);

        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.N) {
            NumberFormat n = NumberFormat.getCurrencyInstance(Locale.US);
            taxRate.setText("Tax Rate "+ Double.toString(rate.doubleValue()) +"%");
            taxAmount.setText("Tax Amount" + n.format(amount.doubleValue()));
        }
        else{
            taxRate.setText("Tax Rate "+ Double.toString(rate.doubleValue()) +"%");
            taxAmount.setText("Tax Amount " + Double.toString(amount.doubleValue()));
        }

    }

    public void setSeek(int value){
        seekBar.setProgress(value);
    }


}
