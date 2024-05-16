package com.example;

import java.io.IOException;
import java.util.List;
import java.util.ArrayList;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.paint.Color;
import javafx.scene.paint.Paint;
import javafx.scene.text.Font;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import javafx.scene.shape.*;

/**
 * JavaFX App
 */
public class App extends Application {

    private static Scene scene;

    @Override
    public void start(Stage stage) throws IOException {
        scene = new Scene(loadFXML("primary"), 800, 600);

        // Instancia group pre pridanie dedica do sceny
        Group root = new Group();
        scene.setRoot(root);

        // Objekty pridane do sceny
        UiText text = new UiText();
        Text autorText = text.autor();

        Hviezda hviezda = new Hviezda();
        Path path = hviezda.kresba();

        Dom dom = new Dom();
        Rectangle stena = dom.stena();
        Rectangle oknoL = dom.okna(510, 320);
        Rectangle oknoP = dom.okna(580, 320);
        Rectangle dvere = dom.dvere();

        // Pridavanie do sceny
        root.getChildren().addAll(autorText, path, stena, oknoL, oknoP, dvere);

        stage.setScene(scene);
        stage.show();
    }

    // Vsetky ostatne metody
    static void setRoot(String fxml) throws IOException {
        scene.setRoot(loadFXML(fxml));
    }

    private static Parent loadFXML(String fxml) throws IOException {
        FXMLLoader fxmlLoader = new FXMLLoader(App.class.getResource(fxml + ".fxml"));
        return fxmlLoader.load();
    }

    public static void main(String[] args) {
        launch();
    }

}

// Trieda pre vytvorenie hviezdy
class Hviezda {

    public Path kresba() {
        Path path = new Path();

        MoveTo moveTo = new MoveTo(229, 80);

        LineTo lineTo1 = new LineTo(83, 442);
        LineTo lineTo2 = new LineTo(425, 223);
        LineTo lineTo3 = new LineTo(25, 225);
        LineTo lineTo4 = new LineTo(368, 442);
        LineTo lineTo5 = new LineTo(229, 80);

        path.getElements().addAll(moveTo, lineTo1, lineTo2, lineTo3, lineTo4, lineTo5);

        return path;
    }
}

// Trieda ore vytvorenie domu
class Dom {
    // Metoda vytvorenia zakladu domu
    public Rectangle stena() {
        Rectangle stena = new Rectangle(150, 150, Color.GRAY);
        stena.setStroke(Color.BLACK);
        stena.setStrokeWidth(2);
        stena.setX(500);
        stena.setY(300);
        return stena;
    }

    // Metoda pre vytvorenie okien
    public Rectangle okna(double x, double y) {
        Rectangle okno = new Rectangle(60, 50, Color.BLUE);
        okno.setStroke(Color.BLACK);
        okno.setStrokeWidth(2);
        okno.setX(x);
        okno.setY(y);
        return okno;
    }

    // Metoda pre vytvorenie dveri
    public Rectangle dvere() {
        Rectangle door = new Rectangle(40, 75, Color.BROWN);
        door.setStroke(Color.BLACK);
        door.setStrokeWidth(2);
        door.setX(555);
        door.setY(375);
        return door;
    }

    // public TriangleMesh strecha(){

    // }
}

// Trieda na vytvorenie textu v okne
class UiText {

    // Meno autora
    public Text autor() {
        Text txt = new Text(650, 575, "Michal Tynik");
        txt.setFont(new Font(20));
        return txt;
    }
}