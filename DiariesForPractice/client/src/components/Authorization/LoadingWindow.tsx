import React, { Component } from "react";
import ReactLoading from "react-loading";

class LoadingWindow extends Component {
    renderLoading() {
        return (
            <ReactLoading type="spin" color="#fff" />
        );
    }
    
    render() {
        return(
            <div className="row justify-content-center">
                {this.renderLoading()}
            </div>
        );
    }
}

export default LoadingWindow;