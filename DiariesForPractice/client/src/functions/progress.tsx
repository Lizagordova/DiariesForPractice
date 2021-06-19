import React from "react";

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
    
    if(progressBar !== null) {
        // @ts-ignore
        let bar = progressBar[0];
        if(bar !== undefined) {
            bar.style.width = progress;
        }       
    }
}