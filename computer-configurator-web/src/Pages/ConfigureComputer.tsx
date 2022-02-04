import { useEffect, useState } from "react";

import useIntroPage, { IntroConfig } from "../Components/IntroPage/useIntroPage";
import useStepWizard from "../Components/StepWizard/useStepWizard";
import useSelectPart from "../Components/SelectPart/useSelectPart";

import { AllCPU } from "../Services/CPU.service";
import { AllRAM } from "../Services/RAM.service";

export default function ConfigureComputer() {
	//on startup
	useEffect(() => {
		let hideIntro = localStorage.getItem("configuratorIntroHidden");
		//parsing the value is uneccesary;
		//the presence of a boolean is a sufficient indicator.
		if (hideIntro !== null) setIntroAcknowledged(true);
	}, []);

	const [introAcknowledged, setIntroAcknowledged] = useState<boolean>(false);
	const introPage = useIntroPage({
		wizardName: "computer configurator",
		wizardDescription: "description of what it does.",
		setIntroAcknowledged: setIntroAcknowledged
	} as IntroConfig);

	const [selectedCPU, setSelectedCPU] = useState<number | undefined>();
	const cpuSelection = useSelectPart(1, selectedCPU, setSelectedCPU, "CPU/All", AllCPU);

	const [selectedRAM, setSelectedRAM] = useState<number | undefined>();
	const ramSelection = useSelectPart(2, selectedRAM, setSelectedRAM, "RAM/All", AllRAM);

	let wizardSteps: Array<JSX.Element> = [cpuSelection, ramSelection];

	function submitStep() {
		return <div>Submit</div>;
	}

	const computerConfiguratorWizard = useStepWizard(wizardSteps, submitStep());

	if (!introAcknowledged) return introPage;
	else return computerConfiguratorWizard;
}
