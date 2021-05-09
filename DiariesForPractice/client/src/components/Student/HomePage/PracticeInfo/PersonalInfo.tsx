import React, { Component } from "react";
import { observer } from "mobx-react";
import { RootStore } from "../../../../stores/RootStore";

class PersonalInfoProps {
    store: RootStore;
    edit: boolean;
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