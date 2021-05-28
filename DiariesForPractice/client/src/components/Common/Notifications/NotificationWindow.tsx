import React, { Component } from "react";
import { observer } from "mobx-react";

class NotificationWindowProps {
    
}

@observer
class NotificationWindow extends Component<NotificationWindowProps> {
    constructor(props: NotificationWindowProps) {
        super(props);
    }
    
    render() {
        return(
            <></>
        );
    }
}

export default NotificationWindow;