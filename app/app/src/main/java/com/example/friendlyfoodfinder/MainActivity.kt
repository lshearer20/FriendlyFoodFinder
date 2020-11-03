package com.example.friendlyfoodfinder

import android.content.Intent
import android.os.Bundle
import com.google.android.material.snackbar.Snackbar
import com.google.android.material.navigation.NavigationView
import androidx.core.view.GravityCompat
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.appcompat.app.AppCompatActivity
import android.view.Menu
import android.view.MenuItem
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.app_bar_main.*
import kotlinx.android.synthetic.main.content_main.*
import com.google.zxing.integration.android.IntentIntegrator
import android.R.attr.data
import android.content.Context
import android.widget.Toast
import com.google.zxing.integration.android.IntentResult

import android.content.SharedPreferences


class MainActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener {

    var currUserName: String = "Albus Percival Wulfric Brian Dumbledore"
    var currUserID: String = "1881"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(toolbar)

        // Reference: https://developer.android.com/training/data-storage/shared-preferences
        // Put user name and id retrieval here
        val sharedPreferences = getApplicationContext().getSharedPreferences("Settings", 0);
        val userID = sharedPreferences.getString("userID", "")
        val username = sharedPreferences.getString("username", "")
        if (userID == "" || username == "" || true) { // if user is not created
            val create_user_intent = Intent(this, CreateUser::class.java)
            startActivity(create_user_intent)
        }
        val sharedPreferences2 = getApplicationContext().getSharedPreferences("Settings", 0);
        var username2 = sharedPreferences2.getString("username", "")
        if (username2 == "")
        {
            mainText.text = "Hello, Welcome"
        }
        else {
            mainText.text = "Hello, " + username2
        }

        val toggle = ActionBarDrawerToggle(
            this, drawer_layout, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close
        )
        drawer_layout.addDrawerListener(toggle)
        toggle.syncState()

        nav_view.setNavigationItemSelectedListener(this)
    }


    override fun onBackPressed() {
        if (drawer_layout.isDrawerOpen(GravityCompat.START)) {
            drawer_layout.closeDrawer(GravityCompat.START)
        } else {
            super.onBackPressed()
        }
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Inflate the menu; this adds items to the action bar if it is present.
        menuInflater.inflate(R.menu.main, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        when (item.itemId) {
            R.id.action_settings -> return true
            else -> return super.onOptionsItemSelected(item)
        }
    }

    override fun onNavigationItemSelected(item: MenuItem): Boolean {
        // Handle navigation view item clicks here.
        when (item.itemId) {
            R.id.nav_camera -> {
                // Handle the camera action
                val intent = Intent(this, scanbarcode_activity::class.java)
                // To pass any data to next activity
                // intent.putExtra("keyIdentifier", value)
                // start your next activity
                startActivity(intent);
            }
            R.id.nav_gallery -> {

            }
            R.id.nav_slideshow -> {
                // Source: https://stackoverflow.com/questions/45518139/kotlin-android-start-new-activity
                val families_intent = Intent(this, ManageFamilies::class.java)
                // To pass any data to next activity
                // intent.putExtra("keyIdentifier", value)
                // start your next activity
                startActivity(families_intent)
            }
            R.id.nav_manage -> {

            }
        }

        drawer_layout.closeDrawer(GravityCompat.START)
        return true
    }
}
