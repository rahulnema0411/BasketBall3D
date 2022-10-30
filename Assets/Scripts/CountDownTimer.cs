using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class CountDownTimer : MonoBehaviour {

	public int time_left;
	public bool show_days_format = true;
	public bool is_topbar_timer = false;
	public bool is_gym_timer = false;
	public bool show_spaces = false;
	public bool hide_seconds = false;

	public System.Action afterCountdown;
	public Action timer_complete_callback = null;
	public Action every_tick_callback = null;
	public bool is_timer_complete = false;
	public bool two_format = false;

	private TextMeshProUGUI tmpro;
	private Text base_text;

	void OnEnable() {
		tmpro = transform.GetComponent<TextMeshProUGUI>();
		base_text = transform.GetComponent<Text>();
		startCountdown();
	}

	public void startCountdown() {
		TimeSpan time_left_span = TimeSpan.FromSeconds(time_left);
		int total_days = (int)Math.Floor(time_left_span.TotalDays);
		if (show_days_format && total_days > 3 && ((time_left - (3 * 24 * 3600)) >= 600)) {
			if (show_spaces) {
				showCountDownWithSpaces(time_left);
			} else if (two_format) {
				showCountDownTwoFormat(time_left);
			} else {
				showCountDownTwoFormat(time_left);
			}
		} else {
			StartCoroutine(CountDownTimerCoroutine());
		}
	}

	IEnumerator CountDownTimerCoroutine() {
		while (time_left >= 0) {
			if (every_tick_callback != null) {
				every_tick_callback();
			}
			if (show_spaces) {
				showCountDownWithSpaces(time_left);
			} else if (two_format) {
				showCountDownTwoFormat(time_left);
			} else {
				showCountDownTwoFormat(time_left);
			}

			var timer = 0f;
			while (timer <= 1f) {
				timer += Time.deltaTime;
				yield return null;
			}

			//yield return new WaitForSeconds(1);

			time_left--;
			if (time_left < 0) {
				time_left = 0;
				if (!is_timer_complete && timer_complete_callback != null) {
					is_timer_complete = true;
					if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToLower() == "mainscene") {
						timer_complete_callback();
					}
				}
			}
		}
	}

	void showCountDown(int time_left) {
		try {
			TimeSpan time_left_span = TimeSpan.FromSeconds(time_left);
			int total_days = (int)Math.Floor(time_left_span.TotalDays);
			if (show_days_format && total_days > 3 && ((time_left - (3 * 24 * 3600)) >= 600)) {
				transform.GetComponent<Text>().text = total_days.ToString("0") + "D  ";
			} else if (is_topbar_timer) {
				if (time_left < 60) {
					transform.GetComponent<Text>().text = time_left_span.Minutes.ToString("00") + ":" + time_left_span.Seconds.ToString("00");
				} else {
					transform.GetComponent<Text>().text = Math.Floor(time_left_span.TotalHours) + ":" + time_left_span.Minutes.ToString("00");
				}
			} else if (is_gym_timer) {
				transform.GetComponent<Text>().text = time_left_span.Minutes.ToString("00") + ":" + time_left_span.Seconds.ToString("00");
			} else {
				if (total_days < 1) {
					transform.GetComponent<Text>().text = Math.Floor(time_left_span.TotalHours).ToString().TrimStart(new char[] { '0' }) + "h " + time_left_span.Minutes.ToString("00").TrimStart(new char[] { '0' }) + "m ";
					if (!hide_seconds) {
						transform.GetComponent<Text>().text += time_left_span.Seconds.ToString("00").TrimStart(new char[] { '0' }) + "s";
					}
				} else {
					double remainingHours = time_left_span.TotalHours - (total_days * 24);
					transform.GetComponent<Text>().text = total_days.ToString("0") + "d  " + Math.Floor(remainingHours).ToString().TrimStart(new char[] { '0' }) + "h " + time_left_span.Minutes.ToString("00").TrimStart(new char[] { '0' }) + "m ";
					if (!hide_seconds) {
						transform.GetComponent<Text>().text += time_left_span.Seconds.ToString("00").TrimStart(new char[] { '0' }) + "s";
					}
				}
			}
		} catch (Exception e) {
		}
	}

	public string getCountDownTimerString() {
		string text = "";
		try {
			TimeSpan time_left_span = TimeSpan.FromSeconds(time_left);
			int total_days = (int)Math.Floor(time_left_span.TotalDays);
			if (show_days_format && total_days > 3 && ((time_left - (3 * 24 * 3600)) >= 600)) {
				text = total_days.ToString("0") + "D  ";
			} else if (is_topbar_timer) {
				if (time_left < 60) {
					text = time_left_span.Minutes.ToString("00") + ":" + time_left_span.Seconds.ToString("00");
				} else {
					text = Math.Floor(time_left_span.TotalHours) + ":" + time_left_span.Minutes.ToString("00");
				}
			} else if (is_gym_timer) {
				text = time_left_span.Minutes.ToString("00") + ":" + time_left_span.Seconds.ToString("00");
			} else {
				if (total_days < 1) {
					if (time_left_span.TotalHours >= 1) {
						text += Math.Floor(time_left_span.TotalHours).ToString().TrimStart(new char[] { '0' }) + "h ";
					}
					if (time_left_span.TotalMinutes >= 1) {
						text += time_left_span.Minutes.ToString("00").TrimStart(new char[] { '0' }) + "m ";
					}
					if (!hide_seconds) {
						text += time_left_span.Seconds.ToString("00").TrimStart(new char[] { '0' }) + "s";
					}
				} else {
					double remainingHours = time_left_span.TotalHours - (total_days * 24);
					text = total_days.ToString("0") + "d  " + Math.Floor(remainingHours).ToString().TrimStart(new char[] { '0' }) + "h " + time_left_span.Minutes.ToString("00").TrimStart(new char[] { '0' }) + "m ";
					if (!hide_seconds) {
						text += time_left_span.Seconds.ToString("00").TrimStart(new char[] { '0' }) + "s";
					}
				}
			}
		} catch (Exception e) {
		}
		return text;
	}

	void showCountDownWithSpaces(int time_left) {
		try {
			TimeSpan time_left_span = TimeSpan.FromSeconds(time_left);
			int total_days = (int)Math.Floor(time_left_span.TotalDays);
			if (show_days_format && total_days > 2 && ((time_left - (2 * 24 * 3600)) >= 600)) {
				transform.GetComponent<Text>().text = total_days.ToString("0") + "D  ";
			} else if (is_topbar_timer) {
				if (time_left < 60) {
					transform.GetComponent<Text>().text = time_left_span.Minutes.ToString("00") + " : " + time_left_span.Seconds.ToString("00");
				} else {
					transform.GetComponent<Text>().text = Math.Floor(time_left_span.TotalHours) + " : " + time_left_span.Minutes.ToString("00");
				}
			} else if (is_gym_timer) {
				transform.GetComponent<Text>().text = time_left_span.Minutes.ToString("00") + " : " + time_left_span.Seconds.ToString("00");
			} else {
				if (Math.Floor(time_left_span.TotalHours) < 10) {
					transform.GetComponent<Text>().text = "0" + Math.Floor(time_left_span.TotalHours) + " : " + time_left_span.Minutes.ToString("00") + " : " + time_left_span.Seconds.ToString("00");
				} else {
					transform.GetComponent<Text>().text = Math.Floor(time_left_span.TotalHours) + " : " + time_left_span.Minutes.ToString("00") + " : " + time_left_span.Seconds.ToString("00");
				}
			}
		} catch (Exception e) {
		}
	}

	void showCountDownTwoFormat(int time_left) {
		try {
			TimeSpan time_left_span = TimeSpan.FromSeconds(time_left);
			int days = (int)Math.Floor(time_left_span.TotalDays);
			int hours = (int)Math.Floor(time_left_span.TotalHours);
			hours = hours % 24;
			int minutes = time_left_span.Minutes;
			int seconds = time_left_span.Seconds;
			if (days > 0) {
				setTimeText(days.ToString() + "D " + hours.ToString() + "H " + (two_format ? "" : (minutes.ToString() + "M ")));
			} else if (hours > 0) {
				setTimeText(hours.ToString() + "H " + minutes.ToString() + "M " + (two_format ? "" : (seconds.ToString() + "S")));
			} else if (minutes > 0) {
				setTimeText(minutes.ToString() + "M " + seconds.ToString() + "S");
			} else {
				setTimeText(seconds.ToString() + "S");
			}
		} catch (Exception e) {
		}
	}

	private void setTimeText(string time) {
		if (tmpro != null) {
			tmpro.text = time;
		} else if (base_text != null) {
			base_text.text = time;
		}
	}
}