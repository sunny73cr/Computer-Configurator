import React, { useState } from "react";

import "./useIntroPage.css";

export interface IntroConfig {
	wizardName: string;
	wizardDescription: string;
	setIntroAcknowledged: React.Dispatch<React.SetStateAction<boolean>>;
}

export default function useIntroPage(config: IntroConfig) {
	const [introPreference, setIntroPreference] = useState<boolean>(false);

	return (
		<div className="configuratorIntro">
			<h3>Welcome to the {config.wizardName} wizard</h3>

			<p>{config.wizardDescription}</p>

			<div className="controlBar">
				<div>
					<input id="hideIntro" type="checkbox" checked={introPreference} onChange={() => setIntroPreference(!introPreference)} />
					<label htmlFor="hideIntro">Hide this introduction?</label>
				</div>

				<p className="subtext">This saves a preference to your device</p>

				<button
					onClick={() => {
						if (introPreference) {
							try {
								localStorage.setItem("configuratorIntroHidden", "");
							} catch (error) {
								alert(`We weren't able to set your preference.
                                \nYou may have disabled storage for the site, or we have exceeded the allowance.
                                \nPlease clear this site's data from your browser if you continue to see this error.`);
							}
						}
						config.setIntroAcknowledged(true);
					}}
				>
					OK
				</button>
			</div>
		</div>
	);
}
