import React, { Component } from "react";
import { observer } from "mobx-react";

class PersonalInfoProps {
    
}

@observer
class PersonalInfo extends Component<PersonalInfoProps> {
    constructor(props: PersonalInfoProps) {
        super(props);
    }
    
    render() {
        return(
          <>
          </>  
        );
    }
}

export default PersonalInfo;