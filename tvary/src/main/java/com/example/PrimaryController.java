package com.example;

import java.io.IOException;
import javafx.fxml.FXML;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.shape.*;
import javafx.scene.layout.Pane;

public class PrimaryController {

    @FXML
    private Pane pane;

    @FXML
    public void DrawEllipse(){
        pane.getChildren().clear();
        Ellipse el = new Ellipse(100,100,100,100);
        el.setFill(Color.RED);
        pane.getChildren().add(el);
    }
}
