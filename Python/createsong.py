filename = "equinoxes-raw-8th-notes"
songname = "equinoxes"
fileext = ".txt"

song_start_offset = 2.0
song_runtime = 51 + (2 * 60)

def normalize_times(times):
    for i in range(len(times)):
        times[i] -= song_start_offset
    return times

def calculate_avg_delta(times):
    sum = 0.0
    for i in range(1, len(times)):
        sum += times[i] - times[i - 1]
    ret = sum / len(times)
    return ret

def create_song_raw(times, outfile_name):
    with open(outfile_name, "w") as f:
        reflect   = lambda x : "1" if x % 8 == True else "0"
        alternate = lambda x : "1" if x % 2 == True else "0"
        for i in range(len(times)):
            f.write(str(times[i]) + "\t" + reflect(i) + "\t" + alternate(i) + "\n")

def create_song_deltas(avg_delta):
    new_times = []
    x = 0.0
    while x < song_runtime:
        new_times.append(x)
        x += avg_delta
    
    create_song_raw(new_times, songname + "-deltas" + fileext)
            

def main():
    times = []

    with open(filename + fileext, "r") as f:
        for line in f.readlines():
            line = line.split()[0]
            times.append(float(line))

    times = normalize_times(times)
    avg_delta = calculate_avg_delta(times)

    create_song_raw(times, songname + "-raw" + fileext)
    create_song_deltas(avg_delta)






if __name__ == "__main__":
    main()
