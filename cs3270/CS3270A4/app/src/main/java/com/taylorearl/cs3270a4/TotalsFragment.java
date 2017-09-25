package com.taylorearl.cs3270a4;


import java.math.BigDecimal;
import java.util.Locale;

import android.icu.text.NumberFormat;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;


/**
 * A simple {@link Fragment} subclass.
 */
public class TotalsFragment extends Fragment {


    public TotalsFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_totals, container, false);
    }

    public void updateDisplay(BigDecimal amount){
        TextView totalAmount = (TextView)getView().findViewById(R.id.totalAmount);
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.N) {
            NumberFormat n = NumberFormat.getCurrencyInstance(Locale.US);
            totalAmount.setText(n.format(amount.doubleValue()));
        }
        else{
            totalAmount.setText("$" + Double.toString(amount.doubleValue()));
        }

    }

}
