import React from "react";
import ReactDOM from 'react-dom';

export function renderProgress(update: boolean) {
    return (
        <div id="prog-bar" className="progress">
            <div className="progress-bar" ref="progress1">
            </div>
        </div>
    );
}

export function updateProgress(progress: number) {
    // @ts-ignore
    let progressBar = ReactDOM.findDOMNode(this);
    console.log("progressBar", progressBar);
    if(progressBar !== null) {
        // @ts-ignore
        let bar = progressBar[0];
        if(bar !== undefined) {
            bar.style.width = progress;
        }       
    }
}